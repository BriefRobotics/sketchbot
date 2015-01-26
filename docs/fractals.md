# Fun with Fractals

Once we've learned about [recursion](recursion.md), fractals are a beautiful way to play. A fractal is just a pattern that is "self similar" when we look at it from different "zoom levels".

## Koch Curve

Starting with a straight line:

![Koch 0 sim](media/koch0_sim.png)

If we divide it into thirds and make a triangle bend in it like this:

![Koch 1 sim](media/koch1_sim.png)

We've increased it's length by a third (look at the `perimiter` value). If we take each of the line segments now and do the same, we start to make an interesting pattern:

![Koch 2 sim](media/koch2_sim.png)

Again, we've increased the length by a third (because we've increased each segment by this).

This is a fractal called a Koch Curve. Notice that it is self-similar to the previous instance; by being made of four of them. Continue doing this an we get an increasingly intricate pattern; each a third longer than the last.

![Koch 3 sim](media/koch3_sim.png)
![Koch 4 sim](media/koch4_sim.png)
![Koch 5 sim](media/koch5_sim.png)

The very interesting thing to notice is that as we continue, the length continues to grow by 4/3, but it continues to fit on the Etch A Sketch screen. You can imagine repeating this an _infinite_ number of times and we would theoretically get an _infinitely_ long curve!

It can't be seen on the screen, but here is ten iterations. See that the `perimiter` has grown to more than 7101!

![Koch 10 sim](media/koch10_sim.png)

How do we draw such a complicated beast? Well, the self-similarity is begging for [recursion](recursion.md) to be used.

![Koch curve def](media/koch_curve_def.png)
![Koch def](media/koch_def.png)
![Koch sketch](media/koch_curve_sketch.png)

In this case, we're using _mutual_ recursion. The `curve` is defined in terms of `koch`, which is itself defined in terms of `curve` again. Notice though, that `n` is decreased with each iteration and that when it's ≤ 0 then the curve is a simple line like we started with.

The `perimeter` variable is set to 0 initially and tracks the distance traversed; the sum of all the line segments of length `size`.

## [Koch Snowflake](http://en.wikipedia.org/wiki/Koch_snowflake)

A well known fractal using the Koch Curve is the Koch Snowflake. It's just an equalateral triangle with Koch Curves for sides. Very cool!

![Koch snowflake def](media/koch_snowflake_def.png)
![Koch snowflake sketch](media/koch_snowflake_sketch.png)

This is interesting for the same reason as the Curve. As the number of iterations increases (possibly to _infinity_), the perimeter increases, but the area of this closed shape remains finite. A shape with a finite area, but an infinite perimeter. Very strange indeed!

This is a very important concept in mathematics. Knowing that the area grows by less and less with each iteration tells us that it _converges_ at some finite value, while the perimeter grows at a constant rate and so never converges. This concept of knowing the _limits_ of a process is an important one in calculus and a small bit of intuition gained from this example might prove useful later!

![Koch 0](media/koch_snowflake0_sim.png)
![Koch 1](media/koch_snowflake1_sim.png)
![Koch 2](media/koch_snowflake2_sim.png)
![Koch 3](media/koch_snowflake3_sim.png)
![Koch 4](media/koch_snowflake4_sim.png)
![Koch 5](media/koch_snowflake5_sim.png)

## [Hilbert Curve](http://en.wikipedia.org/wiki/Hilbert_curve)

The Hilbert Curve too is a fractal with self-similarity. It is what is known as a _space filling_ curve. Here's how it goes. 

![Hilbert 1](media/hilbert1_sim.png)
![Hilbert 2](media/hilbert2_sim.png)
![Hilbert 3](media/hilbert3_sim.png)
![Hilbert 4](media/hilbert4_sim.png)
![Hilbert 5](media/hilbert5_sim.png)
![Hilbert 6](media/hilbert6_sim.png)
![Hilbert 7](media/hilbert7_sim.png)
![Hilbert 8](media/hilbert8_sim.png)

As the number of iterations increases, it fills the area. With lines as thick as an Etch A Sketch, it seems to fill completely within 10 iterations or so.

A subtile point though is that, given any line thickness (except zero; in which case the lines wouldn't exist!), it will eventually fill an area after some number of iterations. It's another lesson in _limits_.

[Side note: This is a fun one to run on the robot and see it clear the whole screen!]

It too is defined rather simply, but [recursively](recursive.md).

![Hilbert interation def](media/hilbert_iteration_def.png)
![Hilbert def](media/hilbert_def.png)
![Hilbert sketch](media/hilbert_sketch.png)

## [Sierpinski Triangle](http://en.wikipedia.org/wiki/Sierpinski_triangle)

The Sierpinski Triangle is something like the _opposite_ to the Hilbert Curve. Rather than _fill_ space, it's area is _reduced_ with each iteration until it disappears!

![Sierpinski 1](media/sierpinski1_sim.png)
![Sierpinski 2](media/sierpinski2_sim.png)
![Sierpinski 3](media/sierpinski3_sim.png)
![Sierpinski 4](media/sierpinski4_sim.png)
![Sierpinski 5](media/sierpinski5_sim.png)
![Sierpinski 6](media/sierpinski6_sim.png)
![Sierpinski 7](media/sierpinski7_sim.png)

If we could draw with infinitesimally thin lines, then we could watch it reduce to nothing.

The program is similarly defined with a pair of mutually recursive `sierpinski` and `iteration` words.

![Sierpinski interation def](media/sierpinski_iteration_def.png)
![Sierpinski def](media/sierpinski_def.png)
![Sierpinski sketch](media/sierpinski_sketch.png)

A filled triangle is just a bunch of triangles within triangles, by the way:

![Filled triangle](media/filled_triangle_def.png)

## [Dragon Curve](http://en.wikipedia.org/wiki/Dragon_curve)

As a finale, here is a very beautiful one. Both the code and the result are quite interesting.

![Dragon 0](media/dragon0_sim.png)
![Dragon 1](media/dragon1_sim.png)
![Dragon 2](media/dragon2_sim.png)
![Dragon 3](media/dragon3_sim.png)
![Dragon 4](media/dragon4_sim.png)
![Dragon 5](media/dragon5_sim.png)
![Dragon 6](media/dragon6_sim.png)
![Dragon 7](media/dragon7_sim.png)
![Dragon 8](media/dragon8_sim.png)
![Dragon 9](media/dragon9_sim.png)
![Dragon 10](media/dragon10_sim.png)
![Dragon 11](media/dragon11_sim.png)
![Dragon 12](media/dragon12_sim.png)
![Dragon 13](media/dragon13_sim.png)
![Dragon 14](media/dragon14_sim.png)
![Dragon 15](media/dragon15_sim.png)
![Dragon 16](media/dragon16_sim.png)

Using [higher order functions](hof.md) makes the implementation very concise. It's actually astounding the intricate beauty that can be defined with so little code.

![Dragon interation def](media/dragon_iteration_def.png)
![Dragon def](media/dragon_def.png)
![Dragon sketch](media/dragon_sketch.png)

Have fun!
