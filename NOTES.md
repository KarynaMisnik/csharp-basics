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
- [Inheritance and Polymorphism](#inheritance-and-polymorphism)
- [Access modifiers](#access-modifiers)
  - [1. Public](#public)
  - [2. Private](#private)
  - [3. Protected](#protected)
  - [4. Internal](#internal)
- [Encapsulation with properties](#encapsulation-with-properties)
  - [1. Example: Product class](#example-product-class)
  - [2. Understanding the syntax](#understanding-the-syntax)
  - [3. Why price and Price?](#why-price-and-price)
  - [4. Getter syntax](#getter-syntax)
  - [5. Using the class](#using-the-class)
  - [6. Encapsulation](#encapsulation)
  - [7. Connection to constructors](#connection-to-constructors)
- [Property patterns](#property-patterns)
  - [1. Private Setter — get; private set;](#private-setter—get-private-set)
  - [2. Init-only Property — get; init;](#init-only-property—get-init)
  - [3. Computed Property](#computed-property)
  - [4. Property With a Default Value](#property-With-a-default-value)
  - [5. Summary](#summary)
- [Static members](#static-members)

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

### Inheritance and Polymorphism

| Concept | Meaning | Example |
|---|---|---|
| **Encapsulation** | Controls access to an object's data using properties and access modifiers. | `private`, `public`, `get`, `set` |
| **Inheritance** | A class inherits members from another class. | `class Dog : Animal` |
| **Polymorphism** | Different object types can respond differently to the same method call. | `animal.MakeSound()` |
| **Abstraction** | Hides implementation details and exposes essential functionality. | `abstract class`, `interface` |

### 1. Inheritance — "is a"

A derived class inherits accessible members from a base class.

```csharp
class Animal
{
    public string Name { get; set; } = "";
}

class Dog : Animal
{
}
```

`Dog` inherits `Name` from `Animal`.

### 2. Polymorphism — "many forms"

Different classes can provide different implementations of the same inherited method.

```csharp
class Animal
{
    public virtual string MakeSound() => "Some sound";
}

class Dog : Animal
{
    public override string MakeSound() => "Woof";
}

class Cat : Animal
{
    public override string MakeSound() => "Meow";
}
```

```csharp
Animal animal1 = new Dog();
Animal animal2 = new Cat();

Console.WriteLine(animal1.MakeSound()); // Woof
Console.WriteLine(animal2.MakeSound()); // Meow
```

### 3. Encapsulation — "protect data"

```csharp
class Person
{
    public string Name { get; private set; } = "";

    public void ChangeName(string name)
    {
        Name = name;
    }
}
```

Other classes can read `Name`, but cannot directly assign it. They must use `ChangeName()`.

### 4. Abstraction — "hide complexity"

```csharp
abstract class Animal
{
    public abstract string MakeSound();
}
```

This defines what derived classes must implement without specifying how.

### Key Difference

- **Inheritance:** What a class *is* and what it inherits.
- **Polymorphism:** How different objects *behave* through a common type.
- **Encapsulation:** Who can access or modify data.
- **Abstraction:** What functionality is exposed without requiring knowledge of its implementation.

**Remember:** Inheritance establishes the relationship; polymorphism allows different behavior through that relationship.

### Access modifiers

Access modifiers control **where classes, methods, fields, and properties can be accessed**.

| Modifier | Accessible from |
|---|---|
| `public` | Anywhere the type is accessible |
| `private` | Only within the declaring class |
| `protected` | Within the declaring class and derived classes |
| `internal` | Within the same assembly (usually the same project) |
| `protected internal` | Same assembly **or** derived classes in other assemblies |
| `private protected` | Same class or derived classes within the same assembly |

### 1. Public

Accessible from other classes.

```csharp
public class Person
{
    public string Name { get; set; } = "";
}

Person anna = new Person();
anna.Name = "Anna"; // Allowed
```

### 2. Private

Accessible only within the declaring class.

```csharp
public class Person
{
    private int age = 25;
}
```

```csharp
Person anna = new Person();
// anna.age; // Error: age is private
```

### 3. Protected

Accessible inside the class and its derived classes.

```csharp
class Animal
{
    protected string Name = "Animal";
}

class Dog : Animal
{
    public void PrintName()
    {
        Console.WriteLine(Name); // Allowed
    }
}
```

### 4. Internal

Accessible within the same assembly, typically the same project.

```csharp
internal class Person
{
    public string Name { get; set; } = "";
}
```

Your console project can use `Person`, but a separate test project cannot directly access this `internal` class without special configuration.

### Access Modifiers on Properties

You can also restrict setters:

```csharp
public string Name { get; private set; } = "";
```

- `get` is public — other classes can read `Name`.
- `set` is private — only the declaring class can change `Name` directly.

### Important Defaults

- Top-level classes without an explicit modifier are `internal`.
- Class members without an explicit modifier are `private`.

**Remember:**

- `public` — accessible from outside.
- `private` — only this class.
- `protected` — this class and derived classes.
- `internal` — this assembly/project.

Use the most restrictive access level that still allows your code to work.

### Encapsulation with properties

### 1. Example: Product class

```csharp
public class Product
{
    private double _price;

    public double Price
    {
        get => _price;

        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Price cannot be negative.");

            _price = value;
        }
    }
}
```

### 2. Understanding the syntax

| Code | Meaning |
|---|---|
| `public class Product` | A class accessible from other classes |
| `private double _price` | Private field storing the actual price |
| `public double Price` | Public property controlling access to `_price` |
| `get => _price` | Returns the stored price |
| `set` | Runs when assigning a new price |
| `value` | Special variable containing the value being assigned |
| `if (value < 0)` | Checks whether the new price is negative |
| `throw` | Raises an exception and stops the assignment |
| `_price = value` | Stores the new value if validation succeeds |

### 3. Why `_price` and `Price`?

These are two different members:

- **`_price`** is a private *field*. It stores the data.
- **`Price`** is a public *property*. It controls access to the field.

The `_` prefix is a common naming convention for private fields. It is not a special C# operator.

The public property can access the private field because both belong to the same class.

### 4. Getter syntax

This:

```csharp
get => _price;
```

is shorthand for:

```csharp
get
{
    return _price;
}
```

The `=>` is called an **expression-bodied member** syntax.

### 5. Using the class

```csharp
Product product = new Product();

product.Price = 100;

Console.WriteLine(product.Price); // 100
```

If we try:

```csharp
product.Price = -20;
```

The setter throws an `ArgumentOutOfRangeException`.

The stored `_price` remains `100`, because the invalid value is rejected before assignment.

### 6. Encapsulation

**Encapsulation means controlling access to an object's internal data.**

Instead of allowing direct modification of `_price`, we use the public `Price` property to validate values.

This helps prevent invalid object states.

### 7. Connection to constructors

The original `Product` class does not declare a constructor, so C# automatically provides a parameterless constructor.

We could also add our own:

```csharp
public Product(double price)
{
    Price = price;
}
```

Then create an object:

```csharp
Product laptop = new Product(799.99);
```

Here:

- `Product` — class
- `laptop` — variable referring to an object
- `new Product(...)` — creates an object and calls its constructor
- `double price` — constructor parameter
- `799.99` — argument
- `Price = price` — passes the parameter's value through the property setter, including validation

**Important:** Using `Price = price` in the constructor ensures that the same validation runs when creating an object.

### Property patterns

## 1. Private Setter — `get; private set;`

```csharp
public string Name { get; private set; }
```

- `public get` — other classes can read the property.
- `private set` — only code inside the declaring class can change it.
- Useful when the class should control changes to its data.

Example:

```csharp
public class Person
{
    public string Name { get; private set; }

    public Person(string name)
    {
        Name = name;
    }
}
```

In `Program.cs`:

```csharp
Person anna = new Person("Anna");

Console.WriteLine(anna.Name); // Anna
anna.Name = "Maria";          // Error: setter is private
```

**Important:** A private setter is not limited to constructors. Other methods inside `Person` can also change `Name`.

## 2. Init-only Property — `get; init;`

```csharp
public int BirthYear { get; init; }
```

- `get` — allows reading the property.
- `init` — allows assigning the property during object initialization.
- After initialization, ordinary code cannot reassign it.

Example:

```csharp
public class Person
{
    public int BirthYear { get; init; }
}
```

In `Program.cs`:

```csharp
Person anna = new Person
{
    BirthYear = 2000
};

Console.WriteLine(anna.BirthYear); // 2000

anna.BirthYear = 1995; // Compilation error
```

The `{ BirthYear = 2000 }` syntax is called an **object initializer**.

An `init` property can also be assigned inside a constructor.

### `private set` vs `init`

| `private set` | `init` |
|---|---|
| Can be changed by methods inside the class | Normally assigned only during initialization |
| Outside code can read but not modify it | Outside code can initialize it if `init` is public |
| Useful for internally controlled changes | Useful for values intended to remain unchanged |

## 3. Computed Property — `=>`

```csharp
public int Age => DateTime.Now.Year - BirthYear;
```

This is a **computed, read-only property**.

Instead of storing an age, C# calculates it whenever we access the property.

The `=>` is shorthand for:

```csharp
public int Age
{
    get
    {
        return DateTime.Now.Year - BirthYear;
    }
}
```

Usage:

```csharp
Console.WriteLine(anna.Age);
```

There is no setter and no separate backing field for `Age`.

**Note:** This calculation gives the difference between calendar years, not necessarily someone's exact age. Exact age also depends on whether their birthday has occurred this year.

## 4. Property With a Default Value

```csharp
public bool IsActive { get; set; } = true;
```

- `bool` — stores `true` or `false`.
- `= true` — provides the initial value.
- `get; set;` — allows reading and changing the property.

Example:

```csharp
Person anna = new Person();

Console.WriteLine(anna.IsActive); // True

anna.IsActive = false;

Console.WriteLine(anna.IsActive); // False
```

The default value is applied when a new object is initialized.

## 5. Summary

| Property pattern | Can read outside? | Can change after creation? |
|---|---|---|
| `get; set;` | Yes | Yes |
| `get; private set;` | Yes | Yes, from inside the class |
| `get; init;` | Yes | Normally no |
| `Age => ...` | Yes | No direct assignment |
| `get; set; = true;` | Yes | Yes |

### Key Takeaways

- **`get`** — reads a property.
- **`set`** — assigns a property value.
- **`private set`** — restricts who can assign it.
- **`init`** — restricts when it can be assigned.
- **`=>`** — provides a shorter expression-based implementation.
- **`= true`** — initializes a property with a default value.

**Remember:** `private set` controls *who* can modify a property, while `init` primarily controls *when* it can be initialized.

### Static Members

### What is `static`?

The `static` keyword means a member belongs to the **class itself**, rather than to an individual object.

Static members can be fields, properties, or methods.

 **Static Properties — Shared Data**

```csharp
public class Person
{
    public string Name { get; set; } = "";
    public static int PersonCount { get; private set; }

    public Person(string name)
    {
        Name = name;
        PersonCount++;
    }
}
```

Usage:

```csharp
Person anna = new Person("Anna");
Person john = new Person("John");

Console.WriteLine(Person.PersonCount); // 2
```

- `Name` — instance property; each object has its own value.
- `PersonCount` — static property; shared across all `Person` objects.
- Access static members using the **class name**.

**Static Methods — No Object Required**

```csharp
public class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
```

Usage:

```csharp
int result = Calculator.Add(2, 3); // 5
```

No `new Calculator()` is needed.

**Static Methods and Pure Functions**

A **pure function**:

- Always returns the same result for the same inputs.
- Does not modify external state or cause side effects.

Example:

```csharp
public static decimal CalculateTotal(decimal price, int nights)
{
    return price * nights;
}
```

This method is both `static` and pure.

**Important:** Not every static method is pure. Static methods can also modify data or perform other operations.

**Static vs. Instance Members**

| Instance | Static |
|---|---|
| Belongs to an object | Belongs to the class |
| Access: `anna.Name` | Access: `Person.PersonCount` |
| Each object has its own instance data | Static data is shared |
| Usually requires an object | No object required |

**When to Use `static`**

- For shared information, such as counters.
- For utility methods and calculations that don't depend on a particular object's state.
- When creating an object would serve no purpose.

**Remember:** `static` answers the question **"Does this belong to an individual object or to the class itself?"**