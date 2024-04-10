using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello FinalProject World!");
        var fileManager = new FileManager();
        var library = new LibraryManagementSystem("Local Library", fileManager);
        library.Run();

        while(library.IsRunning) {
            library.MainMenu();
        }

        System.Console.WriteLine("\nProgram has ended.");
    }
}