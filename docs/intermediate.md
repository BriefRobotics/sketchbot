# Intermediate Turtle Graphics

## Abstraction

One of the most important things in programming within any language is the ability to _abstract_. That is, the ability to create new compound constructs that are indistinguishable from the primitives. In this way you can extend the language; defining increasingly compounded things.

In our Turtle Graphics language here, we have primitives such as `move`, `turn`, `repeat`, ... Let's make a `square` definition from what we created earlier.

![Square definition](media/square_def.png)

We've even parameterized our new word with a size. This way we can _reach in_ and poke values into the defintion without cracking it open. More importantly, without having to know how it works at all. This is how you manage complexity as you make more and more intricate things. We can now use our `square` within a familiar pattern.

![Square pattern sketch](media/square_pattern_sketch.png)
![Square pattern sim](media/square_pattern_sim.png)

## Refactoring

The way it normally goes is that you start out playing around. Maybe to make a rectangle you think of this:

![Rectangle sketch 0](media/rect_sketch0.png)
![Rectangle sim 0](media/rect_sim.png)

Then you notice that each side is the same two steps but with different _parameters_. Once you become sensitive to it, the _don't repeat yourself (DRY)_ principle will make you feel uneasy about even something small like this. So you factor into a new word.

![Side definition](media/side_def.png)

And then reduce the sketch to:

![Rectangle sketch 1](media/rect_sketch1.png)

Hey, you may as well name this `rectangle` sketch and parameterize it by the `width` and `height`.

![Rectangle definition](media/rect_def.png)

And, oh wait, we can now redefine `square` to be simply a `rectangle` with equal sides!

![Square redefinition](media/square_redef.png)

The pretty pattern we made with squares still works with this new definition of `square`. This is an important point. Any sketch using the definition shouldn't know or care how it works.

This idea of making rough sketches (so to speak) and then continually refactoring as you add abstractions and discover more succinct ways of describing what you want is one of the great joys of programming.

## Generality

Let's play with some other shapes. We should be able to make a triangle the same way we made a square, but with fewer sides and tighter turns.

![Triangle oops sketch](media/triangle_oops_sketch.png)
![Triangle oops sim](media/triangle_oops_sim.png)

Oops! I was thinking that the interior angles of an isosceles triangle is 60 degrees. Actually the turn angles in turtle geometry are the _exterior_ angles. We got lucky with the square, where both are 90 degrees. Trying again:

![Triangle sketch](media/triangle_sketch.png)
![Triangle sim](media/triangle_sim.png)

And of course, we should bundle this up and give it a name.

![Triangle def](media/triangle_def.png)

Does anything bother you yet about the definitions we've made so far? How is `triangle` different from `rectangle` or `square`? Why can't we use our `side` definition here?

At the time, we were thinking only about shapes with right-angled corners and so we assumed that `side` with 90 degrees. It's more succinct to make our base definitions as general as possible and then, perhaps, define more specific and specialized things in terms of them.

![Side general def](media/side_general_def.png)

We can then either go into the `rectangle` definition and hardcode 90, or we could define a new `right angle side` and define `rectangle` in terms of this. We'll leave that up to you.

At any rate, we can now make `triangle` more succinct:

![Triangle succinct def](media/triangle_succinct_def.png)

## More Generalization

Defining `square` in terms of `rectangle` couldn't really get more concise, but if we go back and rethink things a bit, we might notice that we could have defined it very similarly to `triangle`:

![Square re-redefinition](media/square_reredef.png)
![Triangle succinct def](media/triangle_succinct_def.png)

Rethinking what you've done and sealed away from time to time is a healty habit. Do you see any generalization we can make here?

Both are really just polygons!

![Polygon def](media/polygon_def.png)

The difference is in the number of sides and the corner angles. A square is a _regular quadrilateral_.

![Triangle polygon def](media/triangle_poly_def.png)
![Square polygon def](media/square_poly_def.png)

Why not go ahead and define a `pentagon`, `hexagon`, ... even a `circle` can be approximated as we did earlier as a many sided polygon.

![Pentagon def](media/pentagon_def.png)
![Hexagon def](media/hexagon_def.png)
![Circle def](media/circle_def.png)

![Shapes sketch](media/shapes_sketch.png)
![Shapes sim](media/shapes_sim.png)
