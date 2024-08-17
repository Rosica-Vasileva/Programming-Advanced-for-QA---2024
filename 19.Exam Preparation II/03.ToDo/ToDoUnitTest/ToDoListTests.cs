using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string title = "Buy groceries";
        DateTime dueDate = new DateTime(2024, 8, 20);

        // Act
        _toDoList.AddTask(title, dueDate);

        // Assert
        // Очакваме правилно форматиран изход с нови редове в Windows формат
        string expectedOutput = "To-Do List:\r\n[ ] Buy groceries - Due: 08/20/2024";
        string actualOutput = _toDoList.DisplayTasks();

        Assert.AreEqual(expectedOutput, actualOutput);
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // TODO: finish the test
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string nonExistentTaskTitle = "Nonexistent Task"; // Заглавие на задача, която не съществува в списъка

        // Act & Assert
        // Опитваме се да маркираме не съществуваща задача и проверяваме дали хвърля ArgumentException
        Assert.Throws<ArgumentException>(() => _toDoList.CompleteTask(nonExistentTaskTitle));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Act
        // Извеждаме задачите, когато списъкът е празен
        string result = _toDoList.DisplayTasks();

        // Assert
        // Очакваме само заглавието на списъка без задачи
        string expectedOutput = "To-Do List:";
        Assert.AreEqual(expectedOutput, result);
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        // Добавяме задачи към списъка
        _toDoList.AddTask("Buy groceries", new DateTime(2024, 8, 20));
        _toDoList.AddTask("Finish homework", new DateTime(2024, 8, 18));
        _toDoList.CompleteTask("Buy groceries"); // Завършваме една от задачите

        // Act
        // Извеждаме задачите
        string result = _toDoList.DisplayTasks();

        // Assert
        // Очакваме правилно форматиран изход с нови редове в Windows формат
        string expectedOutput = "To-Do List:\r\n[✓] Buy groceries - Due: 08/20/2024\r\n[ ] Finish homework - Due: 08/18/2024";
        Assert.AreEqual(expectedOutput, result);
    }
}
