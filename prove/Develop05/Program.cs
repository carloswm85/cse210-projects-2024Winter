using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop05 World!");

        FileManager file = new();
        Menu menu = new(file);

        while (menu.IsRunning)
        {
            menu.DisplayMenu();
        }
        
        System.Console.WriteLine("> THE ETERNAL QUEST PROGRAM HAS ENDED");
    }
}