using NUnit.Framework;

namespace TextProcessor.UnitTests;

[TestFixture]
public class VowelMiddleFilterTests
{
    private VowelMiddleFilter _vowelMiddleFilter;

    [SetUp]
    public void Setup()
    {
        _vowelMiddleFilter = new VowelMiddleFilter();
    }

    [Test]
    public void Apply_RemovesWordsWithMiddleVowel_OddLength()
    {
        // Arrange
        string input = "clean test middle rather";

        // Act
        string result = _vowelMiddleFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("middle rather"));
    }

    [Test]
    public void Apply_RemovesWordsWithMiddleVowel_EvenLength()
    {
        // Arrange
        string input = "what that when test";

        // Act
        string result = _vowelMiddleFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Apply_KeepsWordsWithoutMiddleVowel()
    {
        // Arrange
        string input = "test try brown";

        // Act
        string result = _vowelMiddleFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("try"));
    }

    [Test]
    public void Apply_RemovesWordsWithMiddleVowel_MixedCase()
    {
        // Arrange
        string input = "Test Clean rather";

        // Act
        string result = _vowelMiddleFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("rather"));
    }

    [Test]
    public void Apply_IgnoresNonAlphanumericCharactersInWords()
    {
        // Arrange
        string input = "clean! test? mid#dle @rather";

        // Act
        string result = _vowelMiddleFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("mid#dle @rather"));
    }

    [Test]
    public void Apply_IgnoresShortWords()
    {
        // Arrange
        string input = "a an be";

        // Act
        string result = _vowelMiddleFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo("a"));
    }

    [Test]
    public void Apply_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = _vowelMiddleFilter.Apply(input);

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

}