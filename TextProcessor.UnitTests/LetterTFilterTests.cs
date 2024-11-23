using NUnit.Framework;

namespace TextProcessor.UnitTests;

[TestFixture]
public class LetterTFilterTests
{
    private LetterTFilter _letterTFilter;

    [SetUp]
    public void Setup()
    {
        _letterTFilter = new LetterTFilter();
    }

    [Test]
    public void Apply_RemovesWordsContainingLetterT()
    {
        // Arrange
        string input = "test text apple banana";

        // Act
        string result = _letterTFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("apple banana"));
    }

    [Test]
    public void Apply_IgnoresCaseForLetterT()
    {
        // Arrange
        string input = "Test Apple TEXT Banana";

        // Act
        string result = _letterTFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("Apple Banana"));
    }

    [Test]
    public void Apply_KeepsWordsWithoutLetterT()
    {
        // Arrange
        string input = "apple banana orange";

        // Act
        string result = _letterTFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("apple banana orange"));
    }

    [Test]
    public void Apply_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = _letterTFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Apply_InputWithOnlyWordsContainingLetterT_ReturnsEmptyString()
    {
        // Arrange
        string input = "test text tweet";

        // Act
        string result = _letterTFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }
    
    [Test]
    public void Apply_InputWithSpecialCharactersInWords_IgnoresSpecialCharacters()
    {
        // Arrange
        string input = "t@est apple text! banana";

        // Act
        string result = _letterTFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("apple banana"));
    }
}
