# C# Basics

A collection of C# exercises completed while learning C# and .NET.

## Requirements

- .NET SDK 10

## Project Structure

```text
csharp-basics/
├── Program.cs
├── Exercises/
│   └── PersonEx/
│       ├── Person.cs
│       └── PersonEx.cs
├── CsharpBasics.Tests/
│   └── UnitTest1.cs
└── CsharpBasics.csproj
```

## Running the Application

Open a terminal in the project root:

```powershell
dotnet run
```

The main `Program.cs` calls the exercise to execute:

```csharp
PersonEx.Run(args);
```

## Unit Testing

This project uses **xUnit** for automated unit testing.

### Initial Test Setup

Create an xUnit test project:

```powershell
dotnet new xunit -n CsharpBasics.Tests
```

Add a reference to the main project:

```powershell
dotnet add CsharpBasics.Tests/CsharpBasics.Tests.csproj reference CsharpBasics.csproj
```

Because the test project is inside the main project folder, exclude its C# files from the main project's compilation.

Add to `CsharpBasics.csproj`:

```xml
<ItemGroup>
    <Compile Remove="CsharpBasics.Tests\**\*.cs" />
</ItemGroup>
```

*These setup steps are needed only when creating the test project. They do not need to be repeated after cloning a repository that already includes the configuration.*

### Running Tests

```powershell
dotnet test CsharpBasics.Tests/CsharpBasics.Tests.csproj
```

### Writing Tests

Unit tests follow the **Arrange – Act – Assert** pattern:

1. **Arrange** — prepare test data and objects.
2. **Act** — execute the method being tested.
3. **Assert** — compare the actual result with the expected result.

Example:

```csharp
[Fact]
public void GetAge_ReturnsCorrectAge()
{
    // Arrange
    Person anna = new Person("Anna", 2000);

    // Act
    int result = anna.GetAge(2026);

    // Assert
    Assert.Equal(26, result);
}
```

### xUnit Attributes

- `[Fact]` — a test with fixed values.
- `[Theory]` — a parameterized test.
- `[InlineData(...)]` — supplies input values for a theory.

Example:

```csharp
[Theory]
[InlineData(2000, 2026, 26)]
[InlineData(1995, 2026, 31)]
public void GetAge_ReturnsCorrectAgeForDifferentYears(
    int birthYear,
    int currentYear,
    int expectedAge)
{
    Person person = new Person("Test", birthYear);

    int result = person.GetAge(currentYear);

    Assert.Equal(expectedAge, result);
}
```

## Exercises

### Lecture 1 — Classes and Objects

- Created a `Person` class with properties and a constructor.
- Implemented a `GetAge()` method.
- Overrode `ToString()`.
- Created and iterated over a `List<Person>`.
- Wrote unit tests using xUnit.