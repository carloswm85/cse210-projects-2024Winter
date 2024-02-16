
using System.Net.Http.Headers;

public class Menu
{
	private bool _running;
	private MenuOptions _options;

	public Menu()
	{
		_running = true;
		_options = new MenuOptions();
	}

	public bool IsRunning()
	{
		return _running;
	}

	public int WordsToHide()
	{
		return _options.amountWords;
	}
	public int SelectedVerses()
	{
		return _options.amountVerses;
	}

	public bool ContinuePrompt(bool visibleWords)
	{
		if (!visibleWords)
		{
			_running = false;
			System.Console.WriteLine();
			System.Console.WriteLine(">> ALL WORDS ARE HIDDEN, CAP");
			return false;
		}

		System.Console.WriteLine();

		Console.WriteLine("> Press 'Enter' key to continue or type 'quit' to finish: ");

		ConsoleKeyInfo keyInfo = Console.ReadKey(true); //true here mean we won't output the key to the console, just cleaner in my opinion.
		if (keyInfo.Key == ConsoleKey.Enter)
		{
			Console.Clear();
			System.Console.WriteLine("!! Continue");
			return true;
		}

		var answer = Console.ReadLine();
		if (answer == "quit")
		{
			_running = false;
			System.Console.WriteLine("!! Program has quitted");
			return false;
		}

		System.Console.WriteLine();
		Console.Clear();
		System.Console.WriteLine("!! Wrong option. Try again.");
		return this.ContinuePrompt(true);
	}

	internal void SetUp()
	{
		System.Console.WriteLine("Do you want to try one or two verses?");
		int versesToShow = 3;

		while (versesToShow > 2)
		{
			versesToShow = Convert.ToInt32(Console.ReadLine());
			if (versesToShow > 2)
			{
				System.Console.WriteLine("Invalid number. Try again.");
			}
		}

		System.Console.WriteLine("How many words do you want to hide? (Max is 4)");
		int wordsToHide = 5;

		while (wordsToHide > 4)
		{
			wordsToHide = Convert.ToInt32(Console.ReadLine());
			if (wordsToHide > 4)
			{
				System.Console.WriteLine("Invalid number. Try again.");
			}
		}

		_options.amountWords = wordsToHide;
		_options.amountVerses = versesToShow;
	}
}
