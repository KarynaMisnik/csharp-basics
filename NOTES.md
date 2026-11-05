## C-sharp basics: notes

- [Console Project Structure](#console-project-structure)
- [C# compilation](#csharp-compilation)
- [What is NuGet?](#what-is-nuget?)
- [var in C#](#var-in-csharp)
- [Nullability in C#](#nullability-in-Csharp)
- [Strings and interpolation in C#](#strings-and-interpolation-in-Csharp)
- [Arrays, List<T>, and Collections in C#](#arrays-list-T-and-collections-in-Csharp)

### Console Project Structure

A basic C# console project contains a few important files.

```
csharp-basics/
├── CsharpBasics.csproj
├── Program.cs
```

**Program.cs**

The main file where we write C# code.<br>
Contains the instructions the program executes.<br>
Modern C# supports top-level statements, so we don't need to manually create a Main() method for simple programs.<br>

**Example**

<code>Console.WriteLine("Hello, World!");</code>

<code>Console</code> — a class used to interact with the terminal.<br>
<code>WriteLine()</code> — a method that prints text and moves to a new line.<br>

**CsharpBasics.csproj**

The project configuration file.<br>
Uses XML format.<br>
Defines which .NET version the project uses.<br>
Contains project settings and dependencies (additional packages).<br>

```
 <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

| Setting | Purpose |
|---|---|
| `Project Sdk="Microsoft.NET.Sdk"` | Uses the standard .NET SDK to build the project. |
| `PropertyGroup` | Groups project settings together. |
| `OutputType=Exe` | Builds a runnable application. |
| `TargetFramework=net10.0` | Targets .NET 10. |
| `ImplicitUsings=enable` | Automatically imports common namespaces. |
| `Nullable=enable` | Enables compiler checks for possible null reference problems. |

**Remember:** `.csproj` configures the project, while `Program.cs` contains the code we want to execute.

**How the program runs**

We write C# code in Program.cs.<br>
The .NET tools compile the code into an application.<br>
The .NET runtime executes the application.<br>
The result appears in the terminal.<br>

> <code>.NET</code> is the platform and tools used to build and run the application.

### C# compilation

C# source code (.cs) is compiled into Intermediate Language (IL). During normal execution, the .NET runtime (CLR) uses a JIT
compiler to translate IL into machine code that the processor can execute.

```
1. C# source code (.cs)

The code you write in Program.cs
                 ⬇️
                 ⬇️
            C# compiler
                 ⬇️
2. IL (Intermediate Language)

A lower-level set of instructions that .NET understands, but your CPU does not directly execute.
                 ⬇️
                 ⬇️
3. CLR (Common Language Runtime)

The .NET runtime manages execution. Normally, its JIT compiler translates IL into machine code.
                 ⬇️
                 ⬇️
4. Machine code

Instructions your processor can execute.
```

### What is NuGet?

The package manager for .NET, used to install, update, and manage libraries and dependencies in a project.

### <code>var</code> in C#

In C#, you can declare a variable using an <ins>explicit</ins> type 
(int, string, double, etc.) or use <code>var</code>, which lets the compiler 
determine the type automatically.

C#'s var does not make a variable **dynamically** typed.

**When should you use <code>var</code>?**

Use explicit types when you want the type to be immediately clear:

```
string username = "Anna";
int age = 25;
```

Use <code>var</code> when the type is obvious from the assigned value, especially when creating objects:

``` 
var names = new List<string>();
```

### Nullability in C#

**Nullability** means whether a variable is allowed to contain null instead of a value.

<code>null</code> represents the absence of an object or value.

```
string name = "Anna";       // Non-nullable
string? maybeName = null;   // Nullable
int? age = null;            // Nullable integer
```

> **?** indicates that null is allowed.

The compiler warns you when you assign null to a non-nullable reference type such as string.

> Notice that this is normally a warning, not an error. C# does not completely prevent you from assigning null to a reference type.

### Strings and interpolation in C#

**String** — a data type used to store text, written inside double quotes.

**Concatenation** — joining strings using <code>+</code>.

```
string name = "Anna";
Console.WriteLine("Hello, " + name);
```

String interpolation allows you to insert variables or expressions directly into a string using <code>$</code> and <code>{}</code>.

```
string name = "Anna";
int age = 25;

Console.WriteLine($"Hello, {name}! You are {age} years old.");
```

### Arrays, List<T>, and Collections in C#

**Collection** — a general term for a group of elements stored together.

**Arrays** and **lists** are both types of collections.

**Array (T[])** — stores multiple elements of the same type. Its length is fixed after creation.

> T represents the type of elements stored in the list.

### Arrays vs List<T>

| Feature | Array | `List<T>` |
|---|---|---|
| Size | Fixed | Dynamic |
| Access by index | `numbers[0]` | `numbers[0]` |
| Number of elements | `.Length` | `.Count` |
| Add/remove elements | No built-in resizing methods | `.Add()`, `.Remove()` |
| Example | `string[]` | `List<string>` |