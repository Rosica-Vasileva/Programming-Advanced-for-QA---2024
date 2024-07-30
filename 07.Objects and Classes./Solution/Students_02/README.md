using System;
using System.Collections.Generic;

public class Student
{
    // Свойства, описващи студента
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string HomeTown { get; set; }

    // Конструктор за създаване на обект от класа Student
    public Student(string firstName, string lastName, int age, string homeTown)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        HomeTown = homeTown;
    }
}

class Program
{
    static void Main()
    {
        // Лист за съхраняване на студенти
        List<Student> studentsList = new List<Student>();

        // Въвеждане на първоначални данни
        string input = Console.ReadLine();

        // Продължаваме докато входните данни не са "end"
        while (input != "end")
        {
            // Разделяме въведените данни
            string[] studentData = input.Split(" ");

            string firstName = studentData[0];
            string lastName = studentData[1];
            int age = int.Parse(studentData[2]);
            string town = studentData[3];

            // Създаваме обект от клас Student с въведените данни
            Student student = new Student(firstName, lastName, age, town);

            // Добавяме създадения студент в списъка
            studentsList.Add(student);

            // Четем следващия ред с данни
            input = Console.ReadLine();
        }

        // Въвеждаме името на града, от който искаме да търсим студенти
        string searchedCity = Console.ReadLine();

        // Принтираме всички студенти от въведения град
        foreach (Student student in studentsList)
        {
            if (student.HomeTown == searchedCity)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}

