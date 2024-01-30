
using System.Runtime.InteropServices;
using System.Text.Json;

public class Journal
{
	private readonly JsonSerializerOptions _options =
					new() { WriteIndented = false };
	public List<Entry> _entries = new List<Entry>();
	
	public void Display()
	{
		if (!_entries.Any())
		{
			System.Console.WriteLine(">>> ALERT! This journal is empty. <<<");
			System.Console.WriteLine();
			return;
		};
		System.Console.WriteLine("→ Displaying journal entries...");
		System.Console.WriteLine();
		int entriesCount = 1;
		foreach (var entry in _entries)
		{
			System.Console.WriteLine($"Nº {entriesCount++}");
			entry.Display();
		}
	}

	public int GetOptionSelection()
	{
		string options =
	 @"→ Please, select one of the following options for your journal:
    1. Write
    2. Display
    3. Load
    4. Save
    5. Quit
        ";
		System.Console.WriteLine(options);
		System.Console.WriteLine("→ What would you like to do?");
		System.Console.Write("Enter your selection: ");
		int selection = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine();
		return selection;
	}

	internal void Save()
	{
		System.Console.WriteLine("What is the filename? (do not include extension file)");
		System.Console.Write("> ");
		string filename = Console.ReadLine();

		System.Console.WriteLine("→ Saving journal...");
		System.Console.WriteLine("");

		var journalEntries = new List<Dictionary<string, string>>();
		foreach (var item in _entries)
		{
			var entry = new Dictionary<string, string>();
			entry.Add("_date", item._date);
			entry.Add("_prompt", item._prompt);
			entry.Add("_response", item._response);
			journalEntries.Add(entry);
		}

		var jsonString = JsonSerializer.Serialize(journalEntries, _options);
		File.WriteAllText($"{filename}.json", jsonString);
	}

	internal void Load()
	{
		System.Console.WriteLine("→ Load journal.");
		System.Console.WriteLine("What is the filename you want to load?");
		System.Console.Write("> ");
		string filename = Console.ReadLine();
		var fileResult = File.ReadAllText($"{filename}.json");
		_entries = JsonSerializer.Deserialize<List<Entry>>(fileResult);
		System.Console.WriteLine("→ Loading journal...");
		System.Console.WriteLine("→ Journal loaded into memoty...");
		System.Console.WriteLine("");
	}

	internal void Write()
	{
		System.Console.WriteLine("→ Write new entry.");
		var entry = new Entry();
		entry._prompt = ShowPrompt();
		System.Console.Write("> ");
		entry._response = System.Console.ReadLine();
		entry._date = DateTime.Now.ToString();
		System.Console.WriteLine("");
		_entries.Add(entry);
	}

	/// <summary>
	/// https://stackoverflow.com/a/2019432/7389293
	/// </summary>
	private string ShowPrompt()
	{
		List<string> prompts = new List<string>{
						"Who was the most interesting person I interacted with today?",
						"What was the best part of my day?",
						"How did I see the hand of the Lord in my life today?",
						"What was the strongest emotion I felt today?",
						"If I had one thing I could do over today, what would it be?",
						"What was the worst part of my day?",
						"What can I improve for tomorrow? And for next week?",
						"Is there anything I can repent of?"
				};

		Random rnd = new Random();
		int randomIndex = rnd.Next(prompts.Count);

		System.Console.WriteLine($"Journal prompt: {prompts[randomIndex]}");
		return prompts[randomIndex];
	}
}