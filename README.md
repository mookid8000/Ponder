What?
====

Ponder is a simple, source-code-only thing, that can help doing common expression reflection tasks in C#.

How?
====

1. Put Ponder.cs in a lib folder in your project.
1. In your project, go to the "Add existing item..." menu, and MARK Ponder.cs (don't SELECT it just yet...)
1. Click that funny little arrow next to the "Add" button
1. Select "Add As Link"

and BAM! - your project should now _reference_ Ponder.cs, thus allowing it to reside in your `lib` folder and be updated like you update all of your other dependencies.

Now you should be able to do stuff like this:

```C#
var path = Reflect.Path<Person>(p => p.FirstName.Length);
// path is "FirstName.Length"
```

License
====

Ponder is [Beer-ware][1].

[1]: http://en.wikipedia.org/wiki/Beerware
[2]: http://twitter.com/#!/mookid8000