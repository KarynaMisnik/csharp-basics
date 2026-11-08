using Xunit;

public class PersonTests
{
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

    [Theory]
    [InlineData(2000, 2026, 26)]
    [InlineData(1995, 2026, 31)]
    [InlineData(2010, 2026, 16)]
    public void GetAge_ReturnsCorrectAgeForDifferentYears(
    int birthYear,
    int currentYear,
    int expectedAge)
    {
        Person person = new Person("Test", birthYear);

        int result = person.GetAge(currentYear);

        Assert.Equal(expectedAge, result);
    }
    [Fact]
    public void Constructor_InitializesProperties()
    {
        // Arrange & Act
        Person anna = new Person("Anna", 2000);

        // Assert
        Assert.Equal("Anna", anna.Name);
        Assert.Equal(2000, anna.BirthYear);
    }
}