using System.ComponentModel;
using System.Net.Http.Headers;

public class Menu
{
	// Private Fields
	private FileManager _fileManager;
	private List<Goal> _goalList;
	private int _points = 0;
	private int _selectedOption;
	private bool _isRunning;
	private List<string> _options;
	private string _fileName;

	// Public Properties
	public bool IsRunning
	{
		get { return _isRunning; }
		set { _isRunning = value; }
	}

	// CTORS
	public Menu(FileManager fileManager)
	{
		_fileManager = fileManager;
		_isRunning = true;
		_fileName = null;
		_goalList = new List<Goal>();
		_options = new List<string> {
			"NULL",
			"Create New Goal",
			"List Goals",
			"Save Goals",
			"Load Goals",
			"Record Event",
			"Clear Goals List",
			"Quit",
		};
	}

	internal void DisplayMenu()
	{
		Console.Clear();
		DisplayPoints(true);
		System.Console.WriteLine("Menu Options:");
		for (int i = 1; i < _options.Count; i++)
		{
			System.Console.Write($"\t{i}");
			System.Console.WriteLine($") {_options[i]}");
		}
		System.Console.WriteLine();
		System.Console.Write("Select an option from the menu: ");
		_selectedOption = Convert.ToInt32(Console.ReadLine());

		switch ((MenuOptions)_selectedOption)
		{
			case MenuOptions.Create:
				System.Console.Clear();
				var goal = CreateGoal();
				_goalList.Add(goal);
				break;
			case MenuOptions.List:
				System.Console.Clear();
				ListGoals();
				break;
			case MenuOptions.Save:
				System.Console.Clear();
				SaveGoals();
				break;
			case MenuOptions.Load:
				System.Console.Clear();
				LoadGoals();
				break;
			case MenuOptions.Record:
				System.Console.Clear();
				RecordEvent();
				break;
			case MenuOptions.Clear:
				System.Console.Clear();
				ClearGoals();
				break;
			case MenuOptions.Quit:
				System.Console.Clear();
				QuitMenu();
				break;
			default:
				throw new Exception("Something went wrong.");
		}
		_selectedOption = 0;
	}

	private void DisplayPoints(bool showLevel = false)
	{
		System.Console.WriteLine();
		System.Console.WriteLine($"You have {_points} point{(_points == 1 ? "" : "s")}.");
		if (showLevel) {
			string level = "";
			if (_points < 100) {
				level = "Peasant";
			}
			if (_points  >= 100) {
				level = "Apprentice";
			}
			if (_points  >= 300) {
				level = "Knight";
			}
			if (_points  >= 500) {
				level = "King";
			}
			System.Console.WriteLine($"Your current level is: {level}");
		}
		System.Console.WriteLine();
	}

	private void ClearGoals()
	{
		_goalList.Clear();
		Console.Clear();
		System.Console.WriteLine("> All goals have been deleted.");
		Pause();
	}

	private void QuitMenu()
	{
		_isRunning = false;
	}

	private void RecordEvent()
	{
		Console.Clear();
		ListGoals(false);
		System.Console.Write("Which goal did you accomplish? ");
		var recordSelection = Convert.ToInt32(Console.ReadLine());
		Goal selectedGoal = _goalList[recordSelection - 1];
		int newPoints = selectedGoal.GetPoints();
		if (newPoints == 0)
		{
			System.Console.WriteLine("This goal has been already completed.");
		}
		else
		{
			_points = _points + newPoints;
			System.Console.WriteLine($"Congratulations! You have earned {newPoints} points!");
			System.Console.WriteLine($"Total points: {_points}");
		}
		Pause();
	}

	private void LoadGoals()
	{
		Console.Clear();
		System.Console.Write("What is the filename for the goal file? ");
		_fileName = Console.ReadLine();
		var content = _fileManager.Load(_fileName);
		_points = Convert.ToInt32(content[0]);
		content = content.Skip(1).ToArray();

		foreach (string line in content)
		{
			string[] parts = line.Split(":");
			string header = parts[0];
			string body = parts[1];
			Goal goal = new Goal();

			string[] bodyContent = body.Split(",");

			switch ((GoalTypes)Enum.Parse(typeof(GoalTypes), header))
			{
				case GoalTypes.SimpleGoal:
					goal = new SimpleGoal(bodyContent);
					break;
				case GoalTypes.EternalGoal:
					goal = new EternalGoal(bodyContent);
					break;
				case GoalTypes.ChecklistGoal:
					goal = new ChecklistGoal(bodyContent);
					break;
				default:
					throw new Exception("Something went wrong.");
			}
			_goalList.Add(goal);
		}
	}

	private void SaveGoals()
	{
		if (_goalList.Count == 0)
		{
			Console.Clear();
			System.Console.WriteLine("> There is no goals to save.");
			Pause();
			return;
		}

		System.Console.Write("What is the filename for the goal file? ");
		_fileName = Console.ReadLine();
		var goalsToFile = new List<string>();

		foreach (Goal goal in _goalList)
		{
			goalsToFile.Add(goal.ToString());
		}

		_fileManager.Save(_fileName, goalsToFile, _points.ToString());
		System.Console.WriteLine("Goals have been saved.");
		Pause();
	}

	private void Pause()
	{
		System.Console.WriteLine(">> Press enter to continue <<");
		while (Console.ReadKey().Key != ConsoleKey.Enter) { }
	}

	private void ListGoals(bool fullView = true)
	{
		if (_goalList.Count == 0)
		{
			Console.Clear();
			System.Console.WriteLine("> The list of goals is empty.");
			Pause();
			return;
		}

		System.Console.WriteLine("> Your goals are:");
		System.Console.WriteLine();
		int count = 1;
		foreach (Goal goal in _goalList)
		{
			var description = goal.Describe(fullView);
			if (fullView)
			{
				System.Console.WriteLine($"{count++}) {description}");
			}
			else
			{
				System.Console.WriteLine($"{count++}) {description}");
			}
		}
		DisplayPoints();
		if (fullView)
		{
			Pause();
		}
	}

	private Goal CreateGoal()
	{
		System.Console.WriteLine("> The type of goals are:");
		System.Console.WriteLine("\t1. Simple Goal");
		System.Console.WriteLine("\t2. Eternal Goal");
		System.Console.WriteLine("\t3. Checklist Goal");
		System.Console.Write("Which type of goal would you like to create? ");
		_selectedOption = Convert.ToInt32(Console.ReadLine());

		System.Console.Write("What is the name of your goal? ");
		var name = System.Console.ReadLine();
		System.Console.Write("What is a short description of it? ");
		var description = System.Console.ReadLine();
		System.Console.Write("What is the amount of points associated with this goal? ");
		var basePoints = Convert.ToInt32(Console.ReadLine());
		Goal goal = new Goal();

		switch ((GoalTypes)_selectedOption)
		{
			case GoalTypes.SimpleGoal:
				var simple = new SimpleGoal(name, description, basePoints);
				simple.SetUp();
				goal = simple;
				break;
			case GoalTypes.EternalGoal:
				var eternal = new EternalGoal(name, description, basePoints);
				eternal.SetUp();
				goal = eternal;
				break;
			case GoalTypes.ChecklistGoal:
				var checklist = new ChecklistGoal(name, description, basePoints);
				checklist.SetUp();
				goal = checklist;
				break;
			default:
				throw new Exception("Something went wrong.");
		}
		return goal;
	}
}

public enum GoalTypes
{
	SimpleGoal = 1,
	EternalGoal,
	ChecklistGoal

}

public enum MenuOptions
{
	Create = 1,
	List,
	Save,
	Load,
	Record,
	Clear,
	Quit
}