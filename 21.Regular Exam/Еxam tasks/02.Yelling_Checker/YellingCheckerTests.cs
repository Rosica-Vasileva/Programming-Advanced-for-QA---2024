using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class YellingCheckerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = "";
        var expected = new Dictionary<string, int>();

        // Act
        var result = YellingChecker.AnalyzeSentence(input);

        // Assert
        Assert.AreEqual(expected, result, "The result for an empty string should be an empty dictionary.");
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyUpperCaseWords_ReturnsDictionaryWithYellingEntriesOnly()
    {
        // Arrange
        string input = "HELLO WORLD";
        var expected = new Dictionary<string, int>
            {
                { "yelling", 2 }
            };

        // Act
        var result = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result, "The result should be a dictionary with 'yelling' entries only.");
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyLowerCaseWords_ReturnsDictionaryWithSpeakingLowerEntriesOnly()
    {
        // Arrange
        string input = "hello world";
        var expected = new Dictionary<string, int>
            {
                { "speaking lower", 2 }
            };

        // Act
        var result = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result, "The result should be a dictionary with 'speaking lower' entries only.");
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyMixedCaseWords_ReturnsDictionaryWithASpeakingNormalEntriesOnly()
    {
        string input = "Hello World"; // Изречението съдържа смес от главни и малки букви
        var expected = new Dictionary<string, int>
            {
                { "speaking normal", 2 } // Очакваме да имаме две думи, които са класифицирани като 'speaking normal'
            };

        // Act
        var result = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result, "The result should be a dictionary with 'speaking normal' entries only.");
    }

    [Test]
    public void Test_AnalyzeSentence_LowerUpperMixedCasesWords_ReturnsDictionaryWithAllTypeOfEntries()
    {
        // Arrange
        string input = "HELLO hello HeLLo"; // Изречението съдържа само главни букви, само малки букви и смесени букви
        var expected = new Dictionary<string, int>
            {
                { "yelling", 1 },         // 'HELLO' е само с главни букви
                { "speaking lower", 1 },  // 'hello' е само с малки букви
                { "speaking normal", 1 }  // 'HeLLo' е смес от главни и малки букви
            };

        // Act
        var result = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEquivalent(expected, result, "The result should be a dictionary with all types of entries.");
    }
}

