
class LibraryManagementSystem
{

	private string _name;
	private int _selectedOption;
	private List<string> _options;




	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	private bool _isRunning;
	public bool IsRunning
	{
		get { return _isRunning; }
		set { _isRunning = value; }
	}




	private FileManager _fileManager;
	public FileManager FileManager
	{
		get { return _fileManager; }
		set { _fileManager = value; }
	}

	private User _user;
	public User User
	{
		get { return _user; }
		set { _user = value; }
	}

	private List<Resource> _resources;
	public List<Resource> Resources
	{
		get { return _resources; }
		set { _resources = value; }
	}

	public LibraryManagementSystem(string libraryName)
	{
		_name = libraryName;
		_options = new List<string> {
			"NULL",
			"Log in",
			"Log out",
			"Register new user",
			"Search user",
			"Add new resource",
			"Modify existing resource",
			"Search resourse catalog",
			"Quit program",
		};
	}

	internal void Run()
	{
		_isRunning = true;
		_fileManager = new FileManager();
	}

	public void MainMenu()
	{
		Console.Clear();
		System.Console.WriteLine("Menu Options:");
		for (int i = 1; i < _options.Count; i++)
		{
			System.Console.Write($"\t{i}");
			System.Console.WriteLine($") {_options[i]}");
		}
		System.Console.WriteLine();
		System.Console.Write("Select an option from the menu: ");
		_selectedOption = Convert.ToInt32(Console.ReadLine());

		System.Console.Clear();
		switch ((MenuOptions)_selectedOption)
		{
			case MenuOptions.LogIn:
				LogIn();
				break;
			case MenuOptions.LogOut:
				LogOut();
				break;
			case MenuOptions.RegisterUser:
				RegisterUser();
				break;
			case MenuOptions.SearchUser:
				SearchUser();
				break;
			case MenuOptions.AddResource:
				AddResource();
				break;
			case MenuOptions.UpdateResource:
				UpdateResource();
				break;
			case MenuOptions.SearchCatalog:
				SearchCatalog();
				break;
			case MenuOptions.QuitProgram:
				QuitProgram();
				break;
			default:
				throw new Exception("Something went wrong.");
		}
		Pause();
		_selectedOption = 0;
	}

	public void LogIn()
	{
		System.Console.WriteLine("Log in");
	}

	public void LogOut()
	{
		System.Console.WriteLine("Log out");
	}

	private void RegisterUser()
	{
		System.Console.WriteLine("RegisterUser");

	}

	private void SearchUser()
	{
		System.Console.WriteLine("SearchUser");

	}

	private void AddResource()
	{
		System.Console.WriteLine("AddResource");

	}

	private void UpdateResource()
	{
		System.Console.WriteLine("UpdateResource");
	}

	public void SearchCatalog()
	{
		System.Console.WriteLine("Search Catalog");
	}

	public void Pause()
	{
		System.Console.WriteLine(">> Press enter to continue <<");
		while (Console.ReadKey().Key != ConsoleKey.Enter) { }
	}
	public void QuitProgram()
	{
		_isRunning = false;
		System.Console.WriteLine("Quitting Library Management System...");
	}
}