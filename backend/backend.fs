open System
open System.Net
open MonoBrick.EV3

let brick = new Brick<Sensor,Sensor,Sensor,Sensor>("usb") // "/dev/rfcomm0"

let rec init () =
    try
        brick.Connection.Open()
        brick.MotorA.Reverse <- false
        brick.MotorD.Reverse <- false
        brick.MotorA.ResetTacho(true)
        brick.MotorD.ResetTacho(true)
        brick.MotorA.SetPower(255uy, true)
        brick.MotorD.SetPower(255uy, true)
    with ex ->
        printfn "ERROR: %s" ex.Message
        brick.Connection.Close()
        init () // try again

let x = ref 0.
let y = ref 0.
let rec plot x' y' =
    let line x0 y0 x1 y1 = seq {
        let steep = abs(y1 - y0) > abs(x1 - x0)
        let x0, y0, x1, y1 = if steep then y0, x0, y1, x1 else x0, y0, x1, y1
        let x0, y0, x1, y1 = if x0 > x1 then x1, y1, x0, y0 else x0, y0, x1, y1
        let dx, dy = x1 - x0, abs(y1 - y0)
        let s = if y0 < y1 then 1. else -1.
        let rec loop e x y = seq {
            if x <= x1 then
                if steep then yield y, x else yield x, y
                if e < dy then yield! loop (e - dy + dx) (x + 1.) (y + s)
                else yield! loop (e - dy) (x + 1.) y }
        yield! loop (dx / 2.) x0 y0 }
    let rec plot' = function
        | (x', y') :: t ->
            let distance (x, y) (x', y') =
                let a, b = (x' - x), (y' - y)
                sqrt (a * a + b * b)
            try
                let threshold = 1.
                let speed = 40y
                let maxdist = 2
                let tx = ref (float (brick.MotorA.GetTachoCount()))
                let ty = ref (float (brick.MotorD.GetTachoCount()))
                printfn "%f, %f -> %f, %f" !tx !ty x' y'
                if distance (!x, !y) (x', y') > threshold then
                    if !tx > x' then // TODO: DRY!
                        brick.MotorA.On(-speed, 2u, false, true)
                        tx := float (brick.MotorA.GetTachoCount())
                        printfn "tx>x'  %f, %f" !tx x'
                    elif !tx < x' then
                        brick.MotorA.On(speed, 2u, false, true)
                        tx := float (brick.MotorA.GetTachoCount())
                        printfn "tx<x'  %f, %f" !tx x'
                    if !ty > y' then
                        brick.MotorD.On(-speed, 2u, false, true)
                        ty := float (brick.MotorD.GetTachoCount())
                        printfn "ty>y'  %f, %f" !ty y'
                    elif !ty < y' then
                        brick.MotorD.On(speed, 2u, false, true)
                        ty := float (brick.MotorD.GetTachoCount())
                        printfn "ty<y'  %f, %f" !ty y'
                plot' t
            with ex ->
                printfn "ERROR: %s" ex.Message
                plot x' y' // try again
        | [] ->
            x := x'
            y := y'
            printfn "DONE"
            brick.MotorA.On(sbyte 0, uint32 0, true, true)
            brick.MotorD.On(sbyte 0, uint32 0, true, true)
    line !x !y x' y' |> List.ofSeq |> plot'

printfn """
Welcome to
 ____  _        _       _     ____        _   
/ ___|| | _____| |_ ___| |__ | __ )  ___ | |_ 
\___ \| |/ / _ \ __/ __| '_ \|  _ \ / _ \| __|
 ___) |   <  __/ || (__| | | | |_) | (_) | |_ 
|____/|_|\_\___|\__\___|_| |_|____/ \___/ \__| 1.0

"""

init ()

printfn """
Let's calibrate the Etch A Sketch!
First manually move it to the top left corner.
Then attach the robot and press right/down arrows until *just* reaching the bottom right corner.
Press ENTER when complete.
"""

plot 100. 100.

let rec calibrate () =
    match Console.ReadKey().Key with
    | ConsoleKey.RightArrow ->
        plot (!x + 1.) !y
        printfn "x: %f, y: %f" !x !y
        calibrate ()
    | ConsoleKey.DownArrow ->
        plot !x (!y + 1.)
        printfn "x: %f, y: %f" !x !y
        calibrate ()
    | ConsoleKey.Enter -> ()
    | _ -> calibrate ()
calibrate ()

if HttpListener.IsSupported then
    let listener = new HttpListener()
    listener.Prefixes.Add("http://127.0.0.1/sketchbot/")
    listener.Start()
    let alive = ref true
    while !alive do
        printfn "Sketchbot listening..."
        let context = listener.GetContext()
        let request = context.Request
        //let response = context.Response
        let x = float request.QueryString.["x"]
        let y = float request.QueryString.["y"]
        printfn "Plot: %f,%f" x y
        //let resp = "<HTML><BODY>Just testing...</BODY></HTML>"
        //let buffer = System.Text.Encoding.UTF8.GetBytes(resp)
        //response.ContentLength64 <- int64 buffer.Length
        //use output = response.OutputStream
        //output.Write(buffer, 0, buffer.Length)
        //output.Close()
    listener.Stop()
else failwith "HttpListener unsupported"