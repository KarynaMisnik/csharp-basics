using System;

public class Person
{
    public string Name { get; set; } = "";
    public int BirthYear { get; set; }
    

    public Person(string name, int year)
	{
		Name  = name;
        BirthYear = year;
	}

    public int GetAge(int currentYear)
    {
        return currentYear - BirthYear;
    }

    public override string ToString()
    {
        return Name;
    }

}
