using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello FinalProject World!");
        var library = new LibraryManagementSystem("Local Library");
        library.Run();

        while(library.IsRunning) {
            library.MainMenu();
        }

        System.Console.WriteLine("\nProgram has ended.");
    }
}