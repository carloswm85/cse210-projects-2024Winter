using System;

/// <summary>
/// Additional features:
/// - User leveling systems depending on user points (Peasant, Apprentice, Knight, King)
/// - ChecklistGoal is marked different than the other types on the option 2
/// - SimpleGoal takes deadline date as additional information, it is saved and loaded.
/// - Extra option for clearing from memory current list
/// - Empty list is informed as such in the console.
/// </summary>
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