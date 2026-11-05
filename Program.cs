List<string> names = ["Alice", "Bob", "Cara"];

foreach (string name in names)
{
    Console.WriteLine($"Hi, {name}!");
}

// With index, when needed
for (int i = 0; i < names.Count; i++)
{
    Console.WriteLine($"{i + 1}. {names[i]}");
}