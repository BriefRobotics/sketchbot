# The Pitch

## Intro

We made a pair of simple robot manipulators that attach to an off the shelf Etch-A-Sketch board, plug into the USB port of your PC and let computer control the drawing. We coupled this it with a unique tutorial and an engaging development environment aimed at making kids of (almost) all ages quickly grasp some of the hardest key concepts behind programming a real robot!

## Summary

Ashley and Greg cut their teeth on professional software and robotics engineering. Experience taught them the key concepts behind what it takes to build complex and intelligent machines. They wanted to teach those concepts to their kids. For that, they wanted to create a hands on study environment that would be fun and simple enough for a 7 y/o to grasp, but still have the complexity of a real world system. 

And the concepts they wanted to teach were some of the harder ones even for professional engineers:

* Simulation
* Asynchronous and event driven programming
* Calibration
* Debugging
* Recursion and loops  
* Sensing
* Emergent behaviour
* Motion Control   
* Coordinate systems

Can an elementary school student truly understand those concepts? Ashley and Greg think yes! Our technique uses simple familiar concepts  and seamlessly introduces harder new ones. Enter the RoboSketch {"note": "this is just a placeholder name, we have think of one"}

## Drawing

Every child loves to draw, which is amazing, because drawing in an incredibly hard cognitive task. Mastering a pencil is like learning another language, only the tools are simple and rules unwritten and self-verifiable. Pictures are drawn slowly, one line at a time, but they communicate instantly and even a very young child can usually tell quickly if he or she has made a little mistake, go back and try to correct it or start over. This quick feedback cycle is what makes drawing so engaging, rarely is it about the end result.

Drawing with Etch a Sketch is actually, quite challenging as it is basically like operating a CNC machine, only you must play the role of the computer controlling the coordinates of the pen in two dimensions. As a drawing tool for humans, it is much harder to learn, but the principles of quick feedback apply here the same. Mistakes are immediately obvious, and it is easy to start over. Making computer control the knobs, and putting you in charge of the computer makes the tool much easier to use. But of course our goal is not just to automate an Etch a Sketch board. It would be kinda cool, but not be too useful. We use this toy differently.

## Robotics

In technical terms - Etch a Sketch is a 2 degree of freedom Cartesian Robot, and we use it as such to teach the common concepts behind programming a robot. The fact that it also draws lines, moves, wiggles, makes noises, and even breaks or makes a mess of things - is the added bonus that actually makes it engaging and educational. Computer-controlled Etch-A-Sketch is a real world robot, which means it can never do a perfect job drawing lines like a computer can on a screen. Getting a machine perform better and better through trial and error, gaining insight into how physical systems work is what separates robotics from computer games. For example, our tutorials are relying heavily on the very fact that no two pieces of hardware are exactly the same. You will see for yourself what term 'out-of-calibration' means, and learn ways to correct it, as you teach your robot about its own deficiencies. Its called parameter tuning. Without it - circles will look a bit like  rounded squares, and a 180 degree turn will not take you back on the same path!

Our development environment, which can be thought of as a control center of the robot, is based on visual programming interface, using a language similar to Scratch developed at MIT, but further simplified and adapted for the RoboSketch. {"segway": "BTW, there is a scratch extension that supposedly allows you to talk to the arduino boards: https://github.com/damellis/A4S"} We think anyone can understand and use it. If your child can read, write and use a mouse - she can use RoboSketch. All you have to do is a little help with plugging the robot to a PC and some supervision at the beginning.

Our tutorials provide a clear guide on getting started with the robot, and introduce progressively more advanced concepts. Lets take a look at a few examples. 

The very first step for the newly connected robot is calibrating it. A daunting task if you ask a roboticist. RoboSketch has no eyes, so we have to teach it where the board starts and ends. In technical terms its called defining a workspace. Following the tutorial, kids move the pointer to the lower left corner, mark it as the start of the board, then move it to the upper right corner, mark it as the end - and voila the robot now knows its limits! Miss this step, and robot will behave badly, define a smaller rectangle, and robot will only draw inside that area! {"comment": "if EtchASketch board breaks every time we go off the edges - this could be a show stopper. We cant expect anyone, let alone kids keep calibration current. Harsha almost broke the CNC test bed coz he forgot to home it before moving. Michael and I have done it more times than I can remember. And that thing supposedly even has limit switches for safety! And we were supposedly good at what we were doing ..."} 

To make a robot move, we simply drop a "move" block into the sketch, select direction, speed or distance, and click it!

## Programming

Asynchronous and event driven programming is one of the key aspects of any real world robotics application, and it is also one of hardest ones to get a handle on. With RoboSketch - its clearly demonstrated. For instance, when a pointer reaches the edge of the drawing board - it can not continue moving in the same direction, so the robot stops! RoboSketch language lets you trap that event with "when" keyword, and lets you decide what to do. Here is a simple sketch {"demo": "wall bounce, draw diamonds"} of it bouncing off the edges and drawing fascinating patterns.

The same 'when' keyword can be used to sense the world around the robot. For example, it can detect when robot is about to cross a line it previously drew, and let you change its course {"demo": "follow parallel to a line"}

Kids can build programs to control the motion of the robot by assigning speeds to each knob, or simply telling the robot where to go on the board. This is called velocity or position control.  It is fun to mix and match those and see the results. {"demo": "drawing a coil or a spiral"} Merely playing with those two modes of control will give kids great intuition about this fairly advanced concept.

As an added bonus for more mature audiences, we will include a library of more sophisticated sketches that for example, can turn a photograph into a piece of modern art {"demo": "drawing Tracy's portrait"}, while at the same time demonstrating some more advanced algorithms, such as traveling salesman problem, or Delaney triangulation.

RoboSketch includes a simulator that lets you quickly test and debug ideas before running it on a robot. It runs much faster than a robot, but sometimes, a sketch that looks fine in a simulator does not quite work right on a robot, and that's great! Figuring out this discrepancy is what highly paid professional engineers do all the time, and your child will develop an intuition for that as well.

## Curriculum

RoboSketch is so simple to use, and even if it break, parts for it are so cheap, that we think it belongs in every classroom. {"demo": "6-10 y/o kids gathered around the robot, watching it draw, as the teacher projects the sketch on a whiteboard"}

We have done all the work to validate that this little machine coupled with this tutorial really does provide a valuable learning tool for kids ages 6 all the way through the middle school. {"note": "by ACTUALLY putting it in front of the kids, and having them use it with our printed tutorial'} With your support we can turn those prototypes into a real product. You can get them for yourself, your kids, their school or donate to a another school of your choice. 

Robotics will be one of the most exciting and interesting occupations of the 21st century, why not give our kids a tool that can spark their passion to build great things for the future? We hope you and your kids will enjoy using RoboSketch as much as we enjoyed developing it.

Thank you and happy roboteering.

# [Next: Getting Started](getting_started.md)
