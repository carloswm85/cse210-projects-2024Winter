using System.ComponentModel;

public class Menu
{
	// Private Fields
	private string _appName;
	private FileManager _fileManager;
	private List<Goal> _goalList;
	private int _points = 0;
	private int _selectedOption;
	private bool _isRunning;
	private List<string> _options;
	private string _fileName;

	// Public Properties
	public List<Goal> GoalList
	{
		get { return _goalList; }
		set { _goalList = value; }
	}
	public string AppName
	{
		get { return _appName; }
		set { _appName = value; }
	}
	public FileManager FileManager
	{
		get { return _fileManager; }
		set { _fileManager = value; }
	}
	public int Points
	{
		get { return _points; }
		set { _points = value; }
	}
	public int SelectedOption
	{
		get { return _selectedOption; }
		set { _selectedOption = value; }
	}
	public bool IsRunning
	{
		get { return _isRunning; }
		set { _isRunning = value; }
	}
	public string FileName
	{
		get { return _fileName; }
		set { _fileName = value; }
	}

	// CTORS
	public Menu(FileManager fileManager)
	{
		_appName = "Eternal Quest";
		_fileManager = fileManager;
		_isRunning = true;
		_fileName = null;
		_goalList = new List<Goal>() {
			new SimpleGoal("My Simple Goal", "This is a simple goal", 235),
			new EternalGoal("My Eternal Goal", "This is an eternal goal", 394),
			new ChecklistGoal("My Checklist Goal", "This is a checklist goal", 44)
		};
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
		System.Console.WriteLine($"You have {_points} point{(_points == 1 ? "" : "s")}.");
		System.Console.WriteLine();
		System.Console.WriteLine("Menu Options:");
		for (int i = 1; i < _options.Count; i++)
		{
			System.Console.Write($"\t{i}");
			System.Console.WriteLine($") {_options[i]}");
		}
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

	private void ClearGoals()
	{
		_goalList.Clear();
		Console.Clear();
		System.Console.WriteLine("> All goals have been deleted.");
		System.Console.WriteLine(">> Press enter to continue <<");
		while (Console.ReadKey().Key != ConsoleKey.Enter) { }
	}

	private void QuitMenu()
	{
		_isRunning = false;
	}

	private void RecordEvent()
	{
		System.Console.WriteLine("> RecordEvent");
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
			System.Console.WriteLine(">> Press enter to continue <<");
			while (Console.ReadKey().Key != ConsoleKey.Enter) { }
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
		System.Console.WriteLine(">> Press enter to continue <<");
		while (Console.ReadKey().Key != ConsoleKey.Enter) { }
	}

	private void ListGoals()
	{
		if (_goalList.Count == 0)
		{
			Console.Clear();
			System.Console.WriteLine("> The list of goals is empty.");
			System.Console.WriteLine(">> Press enter to continue <<");
			while (Console.ReadKey().Key != ConsoleKey.Enter) { }
			return;
		}

		System.Console.WriteLine("> Your goals are:");
		System.Console.WriteLine();
		int count = 1;
		foreach (Goal goal in _goalList)
		{
			var description = goal.Describe();
			if (goal.Completed)
			{
				_points += goal.BasePoints;
			}
			System.Console.WriteLine($"{count++}) {description}");
		}
		System.Console.WriteLine();
		System.Console.WriteLine($"You have {_points} point{(_points == 1 ? "" : "s")}.");
		System.Console.WriteLine();
		System.Console.WriteLine(">> Press enter to continue <<");
		while (Console.ReadKey().Key != ConsoleKey.Enter) { }
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