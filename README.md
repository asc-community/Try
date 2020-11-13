## Try AngouriMath!

### Jupyter notebooks

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/asc-community/Try/main)

Try it on binder!

<img src="https://github.com/asc-community/AngouriMath/raw/master/additional/readme/interactive.PNG"/>

### AMTerminal

That's a simple terminal for AngouriMath I wrote. It's a console application which
can run some AM's commands.

<img src="./screenshot.png">

#### Syntax

Either directly put an expression to be simplified

```
1 + 2
```

or use syntax

```
[command] << [argument #1] << [argument #2] << ...
```

For example,

```
solve << x << x + 3 = 0 and x > 0
```

or

```
simplify << arcsin(x) + arccos(x)
```