using System;

class Program
{
    static void Main(string[] args)
    {
        var menu = new Menu();
        menu.SetUp();

        var reference = new Reference();
        List<string> content = new List<string>();


        switch (menu.SelectedVerses())
        {
            case 1:
                reference = new Reference("John", 3, 16);
                var verse = "16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
                content = new List<string> { verse };
                break;
            case 2:
                reference = new Reference("Proverbs", 3, 5, 6);
                var verse1 = "5 Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
                var verse2 = "6 In all thy ways acknowledge him, and he shall direct thy paths.";
                content = new List<string> { verse1, verse2 };
                break;
            default:
                System.Console.WriteLine("Something went wrong");
                break;
        }
        
        var scripture = new Scripture(reference, content);

        Console.Clear();
        System.Console.WriteLine(">> App is running.");

        while (menu.IsRunning())
        {
            scripture.RenderScripture();
            if (menu.ContinuePrompt(scripture.VisibleWords()))
            {
                for (int i = 0; i < menu.WordsToHide(); i++)
                {
                    if (scripture.VisibleWords())
                        scripture.HideWords();
                }
            }
        }

    }
}

