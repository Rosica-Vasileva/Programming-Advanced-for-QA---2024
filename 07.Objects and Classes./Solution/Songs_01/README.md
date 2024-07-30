
using System;
using System.Collections.Generic;

public class Song
{
    // Свойства, описващи песента
    public string TypeList { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }

    // Конструктор, създаващ обект от класа
    public Song(string typeList, string name, string time)
    {
        TypeList = typeList;
        Name = name;
        Time = time;
    }
}

class Program
{
    static void Main()
    {
        // Входни данни: броят на песните
        int countSongs = int.Parse(Console.ReadLine());

        // Лист за съхраняване на песните
        List<Song> songsList = new List<Song>();

        for (int count = 1; count <= countSongs; count++)
        {
            // Въвеждане на данни за песента
            string data = Console.ReadLine();
            string[] songData = data.Split('_');

            string typeList = songData[0];
            string songName = songData[1];
            string time = songData[2];

            // Нова песен с въведените данни
            Song song = new Song(typeList, songName, time);

            // Добавяне на създадената песен в списъка
            songsList.Add(song);
        }

        // Вид на песните, които да се отпечатат (или "all")
        string typeSongToPrint = Console.ReadLine();

        // Отпечатване на имената на песните
        foreach (Song song in songsList)
        {
            if (typeSongToPrint == "all" || typeSongToPrint == song.TypeList)
            {
                Console.WriteLine(song.Name);
            }
        }
    }
}
