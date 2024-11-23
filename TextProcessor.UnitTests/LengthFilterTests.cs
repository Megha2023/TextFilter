using NUnit.Framework;

namespace TextProcessor.UnitTests;

[TestFixture]
public class LengthFilterTests
{
    private LengthFilter _lengthFilter;

    [SetUp]
    public void Setup()
    {
        _lengthFilter = new LengthFilter();
    }

    [Test]
    public void Apply_RemovesWordsWithLengthLessThanThree()
    {
        // Arrange
        string input = "a an the dog";

        // Act
        string result = _lengthFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("the dog"));
    }

    [Test]
    public void Apply_KeepsWordsWithLengthThreeOrMore()
    {
        // Arrange
        string input = "cat dog elephant";

        // Act
        string result = _lengthFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("cat dog elephant"));
    }

    [Test]
    public void Apply_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = _lengthFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Apply_InputWithOnlyShortWords_ReturnsEmptyString()
    {
        // Arrange
        string input = "a i o";

        // Act
        string result = _lengthFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Apply_InputWithMixedLengthWords_ReturnsFilteredString()
    {
        // Arrange
        string input = "the a quick brown fox";

        // Act
        string result = _lengthFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("the quick brown fox"));
    }

}
