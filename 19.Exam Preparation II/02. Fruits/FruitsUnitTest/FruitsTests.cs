using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        var fruitDictionary = new Dictionary<string, int>
        {
            { "apple", 5 },
            { "banana", 3 },
            { "cherry", 10 }
        };
        string fruitName = "banana";

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.AreEqual(3, result); // Проверява дали количеството за "banana" е 3
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        var fruitDictionary = new Dictionary<string, int>
        {
            { "apple", 5 },
            { "banana", 3 },
            { "cherry", 10 }
        };
        string fruitName = "orange"; // "orange" не съществува в речника

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.AreEqual(0, result); // Проверява дали резултатът е 0, когато плодът не съществува
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        var fruitDictionary = new Dictionary<string, int>(); // Празен речник
        string fruitName = "apple"; // Плодът "apple", който няма да се намери в празния речник

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.AreEqual(0, result); // Проверява дали резултатът е 0, когато речникът е празен
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int>? fruitDictionary = null; // null речник
        string fruitName = "apple"; // Плодът "apple", който няма да се намери в null речника

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.AreEqual(0, result); // Проверява дали резултатът е 0, когато речникът е null
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        var fruitDictionary = new Dictionary<string, int>
        {
            { "apple", 5 },
            { "banana", 3 },
            { "cherry", 10 }
        };
        string? fruitName = null; // Имаме null за името на плода

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, fruitName);

        // Assert
        Assert.AreEqual(0, result); // Проверява дали резултатът е 0, когато името на плода е null
    }
}
