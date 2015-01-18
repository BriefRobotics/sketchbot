# All About φ and Fibonacci

[Fibonacci](http://en.wikipedia.org/wiki/Fibonacci_number) numbers and [φ](http://en.wikipedia.org/wiki/Golden_ratio) show up again and again in Nature. If you like playing around with numbers (yes, you can **play** with them) then these are some of the most fun.

If you don't believe me, check out this [Vi Hart video on Spirals, Fibonacci and being a plant](https://www.khanacademy.org/math/recreational-math/vi-hart/spirals-fibonacci/v/doodling-in-math-class-spirals-fibonacci-and-being-a-plant-2-of-3).

## Fibonacci

Fibonacci is a sequence of values produced by each being the sum of the previous two; starting with 1 and 1.

    1 + 1 = 2
        1 + 2 = 3
            2 + 3 = 5
                3 + 5 = 8
                    5 + 8 = 13
                        8 + 13 = 21
                            13 + 21 = 34
                                 21 = 34 = 55
                                      34 + 55 = 89
                                           55 + 89 = 144
                                                ...
The sequence 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ... comes out.

This sequence has all kinds of interesting properties, but one is this: if you make fractions out of adjacent pairs, dividing each by its predecessor, you get these:

    1/1    = 1
    2/1    = 2
    3/2    = 1.5
    5/3    = 1.666666666...
    8/5    = 1.6
    13/8   = 1.625
    21/13  = 1.615384615...
    34/21  = 1.619047619...
    55/34  = 1.617647059...
    89/55  = 1.618181818...
    144/89 = 1.617977528...
    ...    = 1.618033989...

Going along, we see that it approaches 1.618033989... This is a very special number! It's been called "the most irrational number" and the "[Golden ratio](http://en.wikipedia.org/wiki/Golden_ratio)". It has many fractal-like self similarities. For example 1 + 1/φ = φ or φ + 1 = φ^2.

# φ

The values `a` and `b` are in the golden ratio if (a + b)/a = a/b. When this is true, a/b = φ.

There are other ways to calculate it (e.g. φ = (1 + sqrt 5) / 2), but the ratios of adjacent Fibonacci numbers is a pretty fun one. Here's a sketch to do it:

![Calc φ def](media/calc_phi_def.png)
![Calc φ sketch](media/calc_phi_sketch.png)

This makes nice use of [recursion](recursion.md). Given a pair of numbers from the sequence, it calculates and graphs the ratio as the best values of φ so far, then moves along using the second number as the new first and the sum of the two as the new second. We go on doing this **forever** (but it'll stop when the graph goes off the screen).

![Calc φ sim](media/calc_phi_sim.png)

You can see visually that it very quickly converges to φ. Pretty neat!

# Golden Rectangles

Let's take a break and play around with an interesting fractal of squares.

![Square fractal def](media/square_fractal_def.png)

Drawing squares beside squares, each smaller than the last by some factor. Let's make each half the size of the previous:

![Square fractal 2 sketch](media/square_fractal_2_sketch.png)
![Square fractal 2 sim](media/square_fractal_2_sim.png)

It makes a nice little spiral of squares. How about making each 2/3rds the previous:

![Square fractal 1.5 sketch](media/square_fractal_1.5_sketch.png)
![Square fractal 1.5 sim](media/square_fractal_1.5_sim.png)

Humm... this time the spiral _grows_.

What value can we use that will be in perfect balance? If you think about it, what we want is a rectangle from which we can subtract a square and get a rectangle _in the same proportions_.

Hey, didn't we say earlier that 1 + 1/φ = φ? That's what we want! If a rectangle is 1 by φ and we subtract and 1 by 1 square from it, that leave a 1 by (φ - 1) rectangle and 1 / (φ - 1) = φ! Okay, **that's** cool!

Let's plug in the φ variable we calculated earlier using Fibonacci ratios:

![Square fractal phi sketch](media/square_fractal_phi_sketch.png)
![Square fractal phi sim](media/square_fractal_phi_sim.png)

Fits _perfectly_!

## Nautilus

If we put arcs inside each square, and use good ol' φ as the growth value.

![Nautilus def](media/nautilus_def.png)
![Nautilus sketch](media/nautilus_sketch.png)

We get the same spiral as is found in a Nautilus shell. How does Nature know about φ?

![Nautilus sim](media/nautilus_sim.png)
![Nautilus shell](media/nautilus_shell.jpg)
