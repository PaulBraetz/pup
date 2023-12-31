# Types
- structural subtyping
  > https://golangdocs.com/interfaces-in-golang
- statically typed
- strongly typed
- user defined conversions
- implicit types?
    ```
    f a := a.foo //a is of type `{ foo }`
    ```
- reference structures
- value structures
    > immutability obviates explicit struct location

    > auto-locate based on size

- union types
- SubsetTypes
- built in encapsulation -> no public fields
- inline class/struct (anonymous types)
- inline interface (anonymous types)
- lambdas as inline interface implementations
  - shorthand struct impl & instantiation 
- boxing? yay or nay?
- Generics
  
# Accessibility
- public
- private (nested types?)
- internal
- explicit vis to other members using `friend`
- file
- namespaces
- using statements
  
# Functions
- static functions?
```
a := {
  f this a := // someA.f
  g a := // a.g someA
  h this a b := // someA.h someB
  i a b := // a.i someA someB
  j this b := // someB.j
  k this b a := // someB a
}
```
- currying
- partial application
- functions may be used/defined as infix, postfix, prefix?
```
(foo) arg1 arg2 := arg1 + arg2 
//type: foo T0{T0+T1:T2} T1{T0+T1:T2} :T2

arg1 arg2 (foo) := arg1 + arg2 
//type: T0{T0+T1:T2} T1{T0+T1:T2} foo :T2

arg1 (foo) arg2 := arg1 + arg2 
//type: T0{T0+T1:T2} foo T1{T0+T1:T2} :T2
```
> _fix syntax pending
- Pattern Matching
- Purity Analysis
  - functions
  - procedures
    > IO allowed generally? Not required if C# interop (C# scripting extension?)?
  > allows for CQRS & general sideeffect analysis?
- operators as functions
> control flow?

# Syntax
*Fields (private by default)*
```
Point := {
  Int32 X;
  Int32 Y
}
```
*Fields with explicit Accessibility*
```
Point3D := {
  public Int32 X;
  internal Int32 Y;
  friend<Matrix3D|{VisitZ Int32}> Int32 Z
}
```
*Parameterized Functions, implicit public ctor*
```
Point := {
  Int32 _x;
  Int32 _y;
  Point WithX Int32 x := Point.New x _y;
  Point WithY Int32 y := { Int32 _x; Int32 _y }.New _x y
}
```
*Inferred Return Types*
```
Point := {
  Int32 _x;
  Int32 _y;
  WithX Int32 x := Point.New x _y; //inferred to `Point`-definition
  WithY Int32 y := { Int32 _x; Int32 _y }.New _x y
  //^inferred to `{ Int32 _x; Int32 _y }`-definition <- equivalent to `Point`-definition
}
```
*Blocks*
```
Foo Int32 a Int32 b :=
{ //braces collide with typesig def?
  z := a + b //inferred type (require keyword to avoid unintended var declarations?)
  z
}
```
*_fix functions*
```
Add(a,b) := a + b; // function '+'  on a or b in scope
z := Add(23 11);
AddInfix(a,,b) := a + b;  // function '+'  on a or b required
zInfix := 23 AddInfix 11;
postfix AddPostfix Int32 a Int32 b := a + b;
zPostfix := 23 11 AddPostfix
```
> how do we bind to contextual expressions properly?

*custom function precedence*
```
infix 1 Add Int32 a Int32 b := a + b;
infix 0 Mul INt32 a INt32 b := a * b;
infix 1 Sub INt32 a Int32 b := a - b;
z := 53 Sub 33 Mul 12 Add 4
```
- case-insensitive names
- arbitrary function names?
- semicolon as separator
    ```
    foo
    ;bar
    ```
    or
    ```
    foo;
    bar
    ```
    instead of 
    ```
    foo;
    bar;
    ```
- no significant whitespace
- comments
  - single line
    ```
    //
    ```
  - multi line
    ```
    /**/
    ```
  - doc comments?
    ```
    ///
    ```
- implicit returns
  - no optional returns => no confusion
- optional scopes (parens)
- mathmatical assign/equality/definition
  ```
  a := b //a is defined as b
  ```
  ```
  a = b //apply infix `=` operator to a and b, nothing special here
  ```
  - this implies `:=` as a reserved operator
    > integrate systematically?
- type aliae

# Execution
- algebraic effects
- exceptions
- lazy/eager eval of variables
- non-breakable immutability?
- green threads
  > https://github.com/dotnet/runtimelab/blob/feature/green-threads/docs/design/features/greenthreads.md

  > https://jayconrod.com/posts/128/goroutines-the-concurrency-model-we-wanted-all-along

  > how to avoid avoid colored functions?
  
# Reflection
- same as compiler api 
  - built in meta programming
  - extend, compile & use types at runtime
  
# General
- C# interop
  - integrate as project embedded script & generated integration members?
    > implement as interpreted script with efficient runtime impl

    > implement as transpiled C#/MSIL; much faster but way harder (mainly due to type system)
- low keyword count

# Inspirations
## Go
- very simple
- stays out of the way
- boring
- interfaces done right
- goroutines
- channels

## C#
- Nullable Flow Analysis
