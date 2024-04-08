
using System.Runtime.InteropServices;

class LibraryManagementSystem
{

	private string _name;
	private int _selectedOption;
	private List<string> _options;
	private List<User> _users = new();




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
			"Search resource catalog",
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
		System.Console.WriteLine("> Register a new user.");
		System.Console.WriteLine();
		var username = GetUserInput("Enter username: ");
		var firstName = GetUserInput("Enter your first name: ");
		var lastName = GetUserInput("Enter your last name: ");
		var email = GetUserInput("Enter your email address: ");
		var password = GetUserInput("Select your user password: ");
		System.Console.WriteLine();
		var userType = GetUserType("Select user type: ");

		switch (userType)
		{
			case UserType.Member:
				var memberType = GetMemberType("Select member type: ");
				_users.Add(new Member(username, firstName, lastName, email, password, memberType));
				break;
			case UserType.Staff:
				var staffType = GetStaffType("Select staff type: ");
				_users.Add(new Staff(username, firstName, lastName, email, password, staffType));
				break;
			default:
				throw new Exception("Something went wrong");
		}
		System.Console.WriteLine($"> New user created");
		System.Console.WriteLine();
		System.Console.WriteLine("User description:");

		// TODO add full description of user data
		System.Console.WriteLine(_users.Last().ToString());
	}

	private string GetUserInput(string diplayedText)
	{
		System.Console.Write(diplayedText);
		return Console.ReadLine();
	}

	private UserType GetUserType(string text)
	{
		System.Console.WriteLine($"> {text}");
		int i = 1;
		foreach (var userType in Enum.GetValues(typeof(UserType)))
		{
			Console.WriteLine($"{i++}) {userType}");
		}
		System.Console.Write("Selection: ");
		int selection = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine();
		switch (selection)
		{
			case 1:
				return UserType.Member;
			case 2:
				return UserType.Staff;
			default:
				System.Console.WriteLine("No option available. Try again.\n");
				return GetUserType(text);
		}
	}
	
	private StaffType GetStaffType(string text)
	{
		System.Console.WriteLine($"> {text}");
		int i = 1;
		foreach (var staffType in Enum.GetValues(typeof(StaffType)))
		{
			Console.WriteLine($"{i++}) {staffType}");
		}
		System.Console.Write("Selection: ");
		int selection = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine();
		switch (selection)
		{
			case 1:
				return StaffType.Librarian;
			case 2:
				return StaffType.Assistant;
			case 3:
				return StaffType.Director;
			case 4:
				return StaffType.Volunteer;
			default:
				System.Console.WriteLine("No option available. Try again.\n");
				return GetStaffType(text);
		}
	}

	private MemberType GetMemberType(string text)
	{
		System.Console.WriteLine($"> {text}");
		int i = 1;
		foreach (var memberType in Enum.GetValues(typeof(MemberType)))
		{
			Console.WriteLine($"{i++}) {memberType}");
		}
		System.Console.Write("Selection: ");
		int selection = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine();
		switch (selection)
		{
			case 1:
				return MemberType.Student;
			case 2:
				return MemberType.Educator;
			case 3:
				return MemberType.Patron;
			case 4:
				return MemberType.Retired;
			case 5:
				return MemberType.Children;
			default:
				System.Console.WriteLine("No option available. Try again.\n");
				return GetMemberType(text);
		}
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