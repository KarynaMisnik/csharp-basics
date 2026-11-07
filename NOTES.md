## C-sharp basics: notes

- [Console Project Structure](#console-project-structure)
- [C# compilation](#csharp-compilation)
- [What is NuGet?](#what-is-nuget?)
- [var in C#](#var-in-csharp)
- [Nullability in C#](#nullability-in-Csharp)
- [Strings and interpolation in C#](#strings-and-interpolation-in-Csharp)
- [Arrays, List<T>, and Collections in C#](#arrays-list-T-and-collections-in-Csharp)
- [Classes: fields, properties, constructor](#classes-fields-properties-constructor)
- [Built-in Classes: Console and Object](#built-in-classes-console-and-object)
- [Override](#override)
  - [1. Creating an Object Without Writing a Constructor](#creating-an-object-without-writing-a-constructor)
  - [2. Writing Constructors](#writing-constructors)
  - [3. How Many Times Does a Constructor Run?](#how-many-times-does-a-constructor-run)
  - [4. Objects and References](#objects-and-references)
  - [5. Overriding ToString()](#overriding-tostring)
  - [6. Key Concepts Summary](#key-concepts-summary)

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

### Classes: fields, properties, constructor

A **class** is a blueprint for creating objects. It groups data and methods together.

- **Field** — a variable declared inside a class that stores data.
- **Property** — provides controlled access to data using `get` and `set`.
- **Constructor** — a special method that runs when an object is created, usually to set initial values.

#### Example

```csharp
class Person
{
    private int age;                         // Field

    public string Name { get; set; }         // Auto-property

    public Person(string name, int age)      // Constructor
    {
        Name = name;
        this.age = age;
    }
}
```

**Creating an object:**

```csharp
Person person = new Person("Anna", 25);

Console.WriteLine(person.Name); // Anna
```

#### Key differences

| Concept | Purpose |
|---|---|
| Field | Stores data inside a class |
| Property | Provides access to data, optionally with validation or other logic |
| Constructor | Initializes an object when it is created |
| `this` | Refers to the current object |
| `new` | Creates a new object |

**Remember:** An auto-property (`{ get; set; }`) automatically creates a hidden field, so you don't need to declare one manually.

### Built-in Classes: Console and Object


C# uses the word **object** in two different ways:

- **Object (`System.Object`)** — a built-in .NET class that provides basic functionality shared by all objects.
- **object** — a general programming term for an instance of a class.

> <code>Object</code> (Capital 'O') and <code>object</code> (Lower case 'o')

#### Example: Class and Object

```csharp
class Person
{
    public string Name { get; set; }
}

Person anna = new Person();
```

- `Person` — our class (blueprint).
- `anna` — a variable referring to an object.
- `new Person()` — creates a new instance of `Person`.

#### `Console` vs `Object`

Both are built-in .NET classes, but their methods are used differently.

| `Console` | `Object` |
|---|---|
| Provides input/output functionality | Provides basic functionality for objects |
| `WriteLine()` is a static method | `ToString()` is an instance method |
| Called using the class name | Called using an object reference |
| `Console.WriteLine("Hello");` | `anna.ToString();` |

#### Why can we call `anna.ToString()`?

Every C# class automatically inherits from `System.Object`, either directly or indirectly.

Therefore, our `Person` class already has access to the `ToString()` method, even though we didn't write it ourselves.

```csharp
Person anna = new Person();

Console.WriteLine(anna.ToString());
```

By default, `ToString()` typically returns the class's name for a simple custom class.

#### Key Concepts

- **Built-in class** — a class provided by .NET, such as `Console` or `Object`.
- **Static method** — called using the class name, without creating an instance.
- **Instance method** — called on an object.
- **Inheritance** — allows a class to reuse functionality defined in another class.

**Remember:** `Object` is not the name of every object. It is a specific built-in class (`System.Object`). The C# keyword `object` is an alias for that type.

`ToString()` is already implemented by .NET. We can use it without writing our own version.

### Override

#### 1. Creating an Object Without Writing a Constructor

```csharp
class Person
{
    public string Name { get; set; } = "";
}

Person anna = new Person();
anna.Name = "Anna";
```

- `Person` is a class (blueprint).
- `new Person()` creates an object.
- If no constructor is declared, C# automatically provides a **parameterless constructor**.
- `Name` initially contains `""` (empty string).
- `anna.Name = "Anna"` uses the property's setter to change its value.

#### 2. Writing Constructors

**Empty constructor:**

```csharp
public Person()
{
}
```

This constructor accepts no arguments. Writing it explicitly is optional when the class has no other constructors.

**Constructor with a parameter:**

```csharp
class Person
{
    public string Name { get; set; } = "";

    public Person(string name)
    {
        Name = name;
    }
}
```

Now we can initialize the name when creating the object:

```csharp
Person anna = new Person("Anna");
```

Here:
- `string name` is a **parameter** in the constructor declaration.
- `"Anna"` is an **argument** passed when calling it.
- `Name = name` assigns the argument's value to the property.

If we declare only `Person(string name)`, then `new Person()` will no longer work unless we also declare a parameterless constructor.

#### 3. How Many Times Does a Constructor Run?

A constructor runs **once each time a new object is created**.

```csharp
Person anna = new Person("Anna"); // Constructor runs once
Person john = new Person("John"); // Constructor runs again
```

Total: **2 constructor calls**.

Changing properties does not call the constructor again:

```csharp
anna.Name = "Maria";
anna.Name = "Kate";
```

The final value is `"Kate"`.

**Constructor vs Setter**

| Constructor | Setter |
|---|---|
| Runs during object creation | Runs when a property is assigned |
| Initializes the object | Changes a property value |
| Called through `new Person(...)` | Used through `anna.Name = ...` |

#### 4. Objects and References

Each `new Person()` creates a separate object.

```csharp
Person anna = new Person("Anna");
Person john = new Person("John");
```

Changing `anna.Name` does not affect `john.Name`.

However:

```csharp
Person anna = new Person("Anna");
Person john = anna;

john.Name = "John";

Console.WriteLine(anna.Name); // John
```

Here, `john = anna` does **not** create another object. Both variables refer to the same object.

Important distinctions:

- Objects **can have their property values changed** if the properties allow it.
- Variables **can be reassigned** to refer to different objects.
- Assigning one class-type variable to another copies the reference, not the object itself.
- Only `new Person(...)` in these examples creates a new `Person` object.

#### 5. Overriding `ToString()`

Every C# class ultimately inherits from the built-in `System.Object` class.

`Object` provides a method called `ToString()`, which returns a string representation of an object.

For a simple `Person` class, the default implementation returns `"Person"`.

We can **override** this method to return our own information.

```csharp
class Person
{
    public string Name { get; set; } = "";

    public Person(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
```

Usage:

```csharp
Person anna = new Person("Anna");

Console.WriteLine(anna.ToString()); // Anna
```

- `override` provides a new implementation of an inherited method that allows overriding.
- `ToString()` returns the object's `Name` instead of the default class name.
- We are not modifying `System.Object` itself.
- The constructor and `ToString()` are independent: the constructor initializes the object, while `ToString()` returns its text representation.

#### 6. Key Concepts Summary

| Concept | Purpose |
|---|---|
| Class | Blueprint for objects |
| Object | Instance of a class |
| `new` | Creates a new object |
| Constructor | Initializes an object during creation |
| Parameter | Variable declared in a constructor or method |
| Argument | Actual value supplied when calling it |
| Property | Provides access to a value through `get` and optionally `set` |
| Setter | Assigns a value to a property |
| Reference | Identifies an existing object |
| `Object` | Built-in base class for C# classes |
| `ToString()` | Returns a string representation of an object |
| `override` | Replaces an inherited method's implementation for the derived class |

**Remember:**

- `new Person()` → creates an object and runs its constructor.
- `anna.Name = "Anna"` → changes a property, not the object itself.
- `Person john = anna` → creates another reference to the same object, not another `Person`.
- `anna.ToString()` → calls the object's string representation method, using our overridden implementation if one exists.