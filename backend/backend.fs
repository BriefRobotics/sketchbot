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
    let distance (x, y) (x', y') =
        let a, b = (x' - x), (y' - y)
        sqrt (a * a + b * b)
    let step = 2u
    let xs, ys = ref 0., ref 0.
    let running = 0.666666
    let driveX s =
        xs := !xs * running + s * (1. - running)
        brick.MotorA.On(sbyte (!xs + 0.5), step, false, true)
    let driveY s =
        ys := !ys * running + s * (1. - running)
        brick.MotorD.On(sbyte (!ys + 0.5), step, false, true)
    let rec plot' = function
        | (x', y') :: t ->
            try
                let speed = 50.
                let threshold = 1.
                let x = float (brick.MotorA.GetTachoCount())
                let y = float (brick.MotorD.GetTachoCount())
                printfn "%f, %f -> %f, %f" x y x' y'
                if distance (x, y) (x', y') > threshold then
                    if   x > x' then driveX -speed
                    elif x < x' then driveX  speed
                    if   y > y' then driveY -speed
                    elif y < y' then driveY  speed
                plot' t
            with ex ->
                printfn "ERROR: %s" ex.Message
                plot x' y' // try again
        | [] ->
            brick.MotorA.On(sbyte 0, uint32 0, true, true)
            brick.MotorD.On(sbyte 0, uint32 0, true, true)
            printfn "DONE"
    let x = float (brick.MotorA.GetTachoCount())
    let y = float (brick.MotorD.GetTachoCount())
    printfn "LINE: %f, %f" x y
    let points = line x y x' y' |> List.ofSeq
    match points with
    | p :: _ ->
        if distance p (x, y) > 0.1 then
            printfn "REVERSE!"
            points |> List.rev |> plot'
        else plot' points
    | [] -> ()

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

let w, h = ref 1600., ref 1100.
let x, y = ref 0., ref 0.
let rec calibrate () =
    match Console.ReadKey(true).Key with
    | ConsoleKey.RightArrow ->
        x := !x + 100.
        plot !x !y
        printfn "x: %f, y: %f" !x !y
        calibrate ()
    | ConsoleKey.DownArrow ->
        y := !y + 100.
        plot !x !y
        printfn "x: %f, y: %f" !x !y
        calibrate ()
    | ConsoleKey.T ->
        w := 1050.
        h := 750.
        printfn "Using travel sized calibration: %f, %f" !w !h
        ()
    | ConsoleKey.Spacebar ->
        printfn "Using default calibration: %f, %f" !w !h
        ()
    | ConsoleKey.Enter ->
        w := !x
        h := !y
        ()
    | _ -> calibrate ()
calibrate ()

if HttpListener.IsSupported then
    let listener = new HttpListener()
    listener.Prefixes.Add("http://127.0.0.1/sketchbot/") // TODO: local IP address for remote access?
    // listener.Prefixes.Add("http://192.168.1.23/sketchbot/") // TODO: local IP address for remote access?
    listener.Start()
    while true do
        printfn "Sketchbot listening..."
        let context = listener.GetContext()
        let request = context.Request
        let response = context.Response
        let x = float request.QueryString.["x"]
        let y = float request.QueryString.["y"]
        printfn "Plot: %f,%f" x y
        plot ((x + 240.) / 480. * !w) -((y + 180.) / 360. * !h)
        //let resp = "<HTML><BODY>Just testing...</BODY></HTML>"
        //let buffer = System.Text.Encoding.UTF8.GetBytes(resp)
        //response.ContentLength64 <- int64 buffer.Length
        //use output = response.OutputStream
        //output.Write(buffer, 0, buffer.Length)
        //output.Close()
        response.Close()
        printfn "RESPONDED"
    listener.Stop()
else failwith "HttpListener unsupported"
