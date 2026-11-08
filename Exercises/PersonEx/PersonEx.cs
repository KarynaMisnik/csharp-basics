using System;

public class PersonEx
{
	

	public static void Run(string[] args)
	{

        List<Person> persons = new List<Person>();

        persons.Add(new Person("Anna", 2000));
		persons.Add(new Person("John", 1998));
		persons.Add(new Person("Maria", 2002));

		foreach (Person person in persons)
		{
			Console.WriteLine($"{person.Name} is {person.GetAge(2026)} years old");
		}
	}
}
