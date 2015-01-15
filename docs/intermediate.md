# Intermediate Turtle Graphics

## Abstraction

One of the most important things in programming within any language is the ability to _abstract_. That is, the ability to create new compound constructs that are indistinguishable from the primitives. In this way you can extend the language; defining increasingly compounded things.

In our Turtle Graphics language here, we have primitives such as `move`, `turn`, `repeat`, ... Let's make a `square` definition from what we created earlier.

![Square definition](media/square_def.png)

We've even parameterized our new word with a size. This way we can _reach in_ and poke values into the defintion without cracking it open. More importantly, without having to know how it works at all. This is how you manage complexity as you make more and more intricate things. We can now use our `square` within a familiar pattern.

![Square pattern sketch](media/square_pattern.png)
![Square pattern sim](media/square_pattern_sim.png)

### Refactoring

The way it normally goes is that you start out playing around. Maybe to make a rectangle you think of this:

![Rectangle sketch 0](media/rect_sketch0.png)
![Rectangle sim 0](media/rect_sim.png)

Then you notice that each side is the same two steps but with different _parameters_. Once you become sensitive to it, the _don't repeat yourself (DRY)_ principle will make you feel uneasy about even something small like this. So you factor into a new word.

![Side definition](media/side_def.png)

And then reduce the sketch to:

![Rectangle sketch 1](media/rect_sketch1.png)

Hey, you may as well name this `rectangle` sketch and parameterize it by the `width` and `height`.

![Rectangle definition](media/rect_def.png)

And, oh wait, we can redefine `square` to be simply a rectangle with equal sides!

![Square redefinition](media/square_redef.png)

This idea of making rough sketches (so to speak) and then continually refactoring as you add abstractionr and discover more succinct ways of describing what you want is one of the great joys of programming.
