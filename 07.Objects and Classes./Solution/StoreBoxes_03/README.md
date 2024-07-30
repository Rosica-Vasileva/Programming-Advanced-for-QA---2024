using System;
using System.Collections.Generic;
using System.Linq;

public class Box
{
    // Свойства, описващи кутията
    public string SerialNumber { get; set; }
    public Item Item { get; set; } // Артикул, който се съхранява в кутията
    public int ItemQuantity { get; set; }
    public double Price { get; set; }

    // Конструктор за създаване на обект от класа Box
    public Box(string serialNumber, Item item, int count)
    {
        SerialNumber = serialNumber;
        Item = item;
        ItemQuantity = count;
        Price = count * item.Price; // Изчислява се общата цена на кутията
    }
}

public class Item
{
    // Свойства, описващи артикула
    public string Name { get; set; }
    public double Price { get; set; }

    // Конструктор за създаване на обект от класа Item
    public Item(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Списък за съхраняване на кутии
        List<Box> boxesList = new List<Box>();

        // Въвеждане на първоначални данни
        string input = Console.ReadLine();

        while (input != "end")
        {
            // Разделяме входните данни
            string[] inputData = input.Split();

            string serialNumber = inputData[0];
            string itemName = inputData[1];
            int itemCount = int.Parse(inputData[2]);
            double itemPrice = double.Parse(inputData[3]);

            // Създаване на артикул
            Item item = new Item(itemName, itemPrice);

            // Създаване на кутия
            Box box = new Box(serialNumber, item, itemCount);

            // Добавяне на кутията в списъка
            boxesList.Add(box);

            // Четене на следващия ред с данни
            input = Console.ReadLine();
        }

        // Сортиране в намаляващ ред по цена
        List<Box> sortedBoxesList = boxesList.OrderByDescending(box => box.Price).ToList();

        // Принтиране на сортирания списък с кутии
        foreach (Box box in sortedBoxesList)
        {
            Console.WriteLine(box.SerialNumber);
            Console.WriteLine($"-- {box.Item.Name} – ${box.Item.Price:F2}: {box.ItemQuantity}");
            Console.WriteLine($"-- ${box.Price:F2}");
        }
    }
}

