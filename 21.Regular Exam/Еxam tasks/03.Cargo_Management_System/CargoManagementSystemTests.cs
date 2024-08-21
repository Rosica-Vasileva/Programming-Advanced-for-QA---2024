using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class CargoManagementSystemTests
{
    [Test]
    public void Test_Constructor_CheckInitialEmptyCargoCollectionAndCount()
    {
        // Arrange
        var system = new CargoManagementSystem();
        int expectedCargoCount = 0;
        var expectedCargos = new List<string>(); // Очакваме празен списък

        // Act
        int actualCargoCount = system.CargoCount;
        var actualCargos = system.GetAllCargos();

        // Assert
        Assert.AreEqual(expectedCargoCount, actualCargoCount, "CargoCount should be 0 for a new CargoManagementSystem instance.");
        CollectionAssert.AreEquivalent(expectedCargos, actualCargos, "The initial cargo collection should be empty.");
    }

    [Test]
    public void Test_AddCargo_ValidCargoName_AddNewCargo()
    {
        // Arrange
        var system = new CargoManagementSystem();
        string newCargo = "New Cargo";
        int expectedCargoCount = 1; // Очакваме броят на товарите да се увеличи с 1
        var expectedCargos = new List<string> { newCargo }; // Очакваме новият товар да бъде в списъка с всички товари

        // Act
        system.AddCargo(newCargo);
        int actualCargoCount = system.CargoCount;
        var actualCargos = system.GetAllCargos();

        // Assert
        Assert.AreEqual(expectedCargoCount, actualCargoCount, "CargoCount should be 1 after adding a new cargo.");
        CollectionAssert.AreEquivalent(expectedCargos, actualCargos, "The cargo list should contain the new cargo.");
    }

    [Test]
    public void Test_AddCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        var system = new CargoManagementSystem();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => system.AddCargo(null), "Expected ArgumentException when adding null cargo.");
        Assert.Throws<ArgumentException>(() => system.AddCargo(string.Empty), "Expected ArgumentException when adding empty cargo.");
        Assert.Throws<ArgumentException>(() => system.AddCargo("   "), "Expected ArgumentException when adding whitespace cargo.");
    }

    [Test]
    public void Test_RemoveCargo_ValidCargoName_RemoveFirstCargoName()
    {
        // Arrange
        var system = new CargoManagementSystem();
        string cargo1 = "First Cargo";
        string cargo2 = "Second Cargo";
        system.AddCargo(cargo1);
        system.AddCargo(cargo2);
        int expectedCargoCount = 1; // Очакваме броят на товарите да намалее на 1
        var expectedCargos = new List<string> { cargo2 }; // Очакваме списъкът да съдържа само втория товар след премахването на първия

        // Act
        system.RemoveCargo(cargo1);
        int actualCargoCount = system.CargoCount;
        var actualCargos = system.GetAllCargos();

        // Assert
        Assert.AreEqual(expectedCargoCount, actualCargoCount, "CargoCount should be 1 after removing the first cargo.");
        CollectionAssert.AreEquivalent(expectedCargos, actualCargos, "The cargo list should contain only the remaining cargo after removing the first one.");
    }

    [Test]
    public void Test_RemoveCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        var system = new CargoManagementSystem();
        string cargo1 = "Cargo to Remove";
        system.AddCargo(cargo1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => system.RemoveCargo(null), "Expected ArgumentException when removing null cargo.");
        Assert.Throws<ArgumentException>(() => system.RemoveCargo(string.Empty), "Expected ArgumentException when removing empty cargo.");
        Assert.Throws<ArgumentException>(() => system.RemoveCargo("   "), "Expected ArgumentException when removing whitespace cargo.");
    }

    [Test]
    public void Test_GetAllCargos_AddedAndRemovedCargos_ReturnsExpectedCargoCollection()
    {
        // Arrange
        var system = new CargoManagementSystem();
        string cargo1 = "Cargo 1";
        string cargo2 = "Cargo 2";
        string cargo3 = "Cargo 3";
        system.AddCargo(cargo1);
        system.AddCargo(cargo2);
        system.AddCargo(cargo3);
        system.RemoveCargo(cargo2); // Премахваме втория товар

        // Очакваме списъкът да съдържа само Cargo 1 и Cargo 3
        var expectedCargos = new List<string> { cargo1, cargo3 };

        // Act
        var actualCargos = system.GetAllCargos();

        // Assert
        CollectionAssert.AreEquivalent(expectedCargos, actualCargos, "The cargo list should match the expected list after adding and removing cargos.");
    }
}

    