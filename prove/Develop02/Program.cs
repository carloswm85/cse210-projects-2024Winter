using System;

class Program
{
    /// <summary>
    /// ADDITIONAL REQUIREMENTS
    /// - Save or load your document to a database or use a different library or format such as JSON for storage.
    /// </summary>
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop02 World!");
        bool running = true;
        int option;
        var journal = new Journal();

        System.Console.WriteLine("~ JOURNAL APP ~");

        do
        {
            option = journal.GetOptionSelection();

            switch (option)
            {
                case 1: // Write
                    journal.Write();
                    break;
                case 2: // Display
                    journal.Display();
                    break;
                case 3: // Load
                    journal.Load();                    
                    break;
                case 4: // Save
                    journal.Save();
                    break;
                case 5: // Quit
                    System.Console.WriteLine("Quitting the progam.");
                    System.Console.WriteLine("Bye :)");
                    running = false;
                    break;
                default:
                    System.Console.WriteLine("Something went wrong.");
                    break;
            }


        } while (running);
    }
}