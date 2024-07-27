string input = Console.ReadLine();

while (input != "end")
{
    //input = "Maria" -> reverse -> "airaM"
    //обръщам текста
    string reversedText = ""; //обърнатия текст
    //всички символи от последния към първия
    for (int position = input.Length - 1; position >= 0; position--)
    {
        char currentSymbol = input[position];
        reversedText += currentSymbol;
        //reversedText = reversedText + currentSymbol;
    }

    //input = "Ivan" -> текст в прав ред
    //reversedText = "navI" -> текст в обърнат ред
    Console.WriteLine(input + " = " + reversedText);


    input = Console.ReadLine();
}
