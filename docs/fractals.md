# Fun with Fractals

Once you've learned about [recursion](recursion.md), fractals are a beautiful way to play. A fractal is just a pattern that is "self similar" when you look at it from different "zoom levels".

## Koch Curve

Imagine you have a straight line:

![Koch 0 sim](media/koch0_sim.png)

If you divide it into thirds and make a triangle bend in it like this:

![Koch 1 sim](media/koch1_sim.png)

You've increased it's length by a third (look at the `perimiter` value). If you take each of the line segments now and do the same, you start to make an interesting pattern:

![Koch 2 sim](media/koch2_sim.png)

Again, you've increased the length by a third (because you've increased each segment by this). This is a fractal. Notice that it is self-similar to the previous instance; by being made of four of them. Continue doing this an you get an increasingly intricate pattern; each a third longer than the last.

![Koch 3 sim](media/koch3_sim.png)
![Koch 4 sim](media/koch4_sim.png)
![Koch 5 sim](media/koch5_sim.png)

The very interesting thing to notice is that as we continue, the length continues to grow by 4/3, but it continues to fit on the Etch A Sketch screen. You can imagine repeating this an _infinite_ number of times and you would theoretically get an _infinitely_ long curve!

It can't be seen on the screen, but here is ten iterations. See that the `perimiter` has grown to more than 7101!

![Koch 10 sim](media/koch10_sim.png)


