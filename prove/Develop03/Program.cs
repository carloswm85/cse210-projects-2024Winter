using System;

class Program
{
    static void Main(string[] args)
    {
        var menu = new Menu();
        menu.SetUp();

        var reference = new Reference("John", 3, 16);
        var verse = "16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        var scriptureWith1Verse = new Scripture(reference, verse);

        var reference2 = new Reference("Proverbs", 3, 5, 6);
        var verse1 = "5 Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        var verse2 = "6 In all thy ways acknowledge him, and he shall direct thy paths.";
        var content = new List<string> { verse1, verse2 };
        var scriptureWith2Verses = new Scripture(reference2, content);

        Console.Clear();
        System.Console.WriteLine(">> App is running.");

        while (menu.IsRunning())
        {
            scriptureWith2Verses.RenderScripture();
            if (menu.ContinuePrompt(scriptureWith2Verses.VisibleWords()))
            {
                for (int i = 0; i < menu.WordsToHide(); i++)
                {
                    if (scriptureWith2Verses.VisibleWords())
                        scriptureWith2Verses.HideWords();
                }
            }
        }

    }
}

