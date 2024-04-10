
using System.Runtime.InteropServices;

class LibraryManagementSystem
{

	private string _name;
	private int _selectedMenuOption;
	private int _selectedSubmenuOption;
	private List<string> _menuOptions;
	private List<string> _submenuOptions;
	private List<User> _users;

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
		_menuOptions = new List<string> {
			"0 INDEX IS NULL",
			"✅ Log in",
			"✅ Log out",
			"✅ Register new user",
			"✅ Search users",
			"❌ Resource manager (books, databases, etc.)",
			"✅ Your profile information",
			"✅ Quit program",
		};
		_submenuOptions = new List<string> {
			"0 INDEX IS NULL",
			"✅ Display resource catalog",
			"✅ Add new resource",
			"❌ Modify resource (update or delete)",
			"✅ Go back"
		};
		_users = new List<User>() {
		new Staff("admin", "Library", "Administrator", "admin@library.org", "Admin123", StaffType.Admin)
		};
		_resources = new List<Resource>() {
			new PhysicalResource(ResourceType.Physical, ResourceCategory.Book,ResourceSubcategory.Literature, "The Lord of the Rings", "J. R. R. Tolkien"),
			new DigitalResource(ResourceType.Digital, ResourceCategory.Book,ResourceSubcategory.Academic, "Another Digital Book", "John D. Doe")
		};
	}

	// TODO display users in a table

	internal void Run()
	{
		_isRunning = true;
		_fileManager = new FileManager();
	}

	public void MainMenu()
	{
		Console.Clear();
		System.Console.WriteLine("Menu Options:");
		for (int i = 1; i < _menuOptions.Count; i++)
		{
			System.Console.Write($"\t{i}");
			System.Console.WriteLine($") {_menuOptions[i]}");
		}
		System.Console.WriteLine();
		System.Console.Write("Select an option from the menu: ");
		_selectedMenuOption = Convert.ToInt32(Console.ReadLine());

		System.Console.Clear();
		switch ((MenuOptions)_selectedMenuOption)
		{
			case MenuOptions.LogIn: // 1
				LogIn();
				break;
			case MenuOptions.LogOut: // 2
				LogOut();
				break;
			case MenuOptions.RegisterUser: // 3
				RegisterUser();
				break;
			case MenuOptions.SearchUser: // 4
				SearchUser();
				break;
			case MenuOptions.ResourceManager: // 5
				ResourceManager();
				break;
			case MenuOptions.UserProfile: // 6
				UserProfile();
				break;
			case MenuOptions.QuitProgram: // 7
				QuitProgram();
				break;
			default:
				throw new Exception("Something went wrong.");
		}
		Pause();
		_selectedMenuOption = 0;
	}

	private void UserProfile()
	{
		System.Console.WriteLine("PROFILE INFORMATION\n");

		if (_user != null)
		{
			System.Console.WriteLine(_user.ToString());
			return;
		}
		System.Console.WriteLine("> There is no user logged in.");
		System.Console.WriteLine();
	}

	public void LogIn()
	{
		System.Console.WriteLine("LOG IN\n");
		var username = GetUserInput("Enter username: ");
		var password = GetUserInput("Enter password: ");
		System.Console.WriteLine();

		User user = _users.FirstOrDefault(u => u.Username == username);

		if (user != null)
		{
			if (user.Password == password)
			{
				_user = user;
				_user.IsLoggedIn = true;
				System.Console.WriteLine("You are logged in.");
				System.Console.WriteLine();
				return;
			}
		}

		System.Console.WriteLine();
		System.Console.WriteLine("> Invalid credentials.");
		System.Console.WriteLine();
	}

	public void LogOut()
	{
		System.Console.WriteLine("LOG OUT\n");

		if (_user != null)
		{
			_user = null;
			System.Console.WriteLine("> You have been logged out.");
			System.Console.WriteLine();
			return;
		}
		System.Console.WriteLine("> There is no user logged in.");
		System.Console.WriteLine();
	}

	private void RegisterUser()
	{
		System.Console.WriteLine("REGISTER NEW USER\n");
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
		// string[] headers = { "Username", "Full Name", "User type", "Registered", "Status" };

		var run = true;

		while (run)
		{
			Console.Clear();
			System.Console.WriteLine("USERS LIST\n");
			var username = GetUserInput("Search by username: ");
			var user = _users.FirstOrDefault(u => u.Username == username);

			if (user != null)
			{
				System.Console.WriteLine("> User found.");
				System.Console.WriteLine();
				System.Console.WriteLine(user.ToString());
			}
			else
			{
				System.Console.WriteLine("User does not exist.");
				System.Console.WriteLine();
			}

			var answer = GetUserInput("> Do you want to search again? (Y/N) ");
			if (answer == "N" || answer == "n")
			{
				run = false;
				Console.Clear();
				System.Console.WriteLine("> Search cancelled by the user.");
				System.Console.WriteLine();
			}
		}
	}

	private void ResourceManager()
	{
		var run = true;

		while (run)
		{
			Console.Clear();
			System.Console.WriteLine("Resource manager options:");

			for (int i = 1; i < _submenuOptions.Count; i++)
			{
				System.Console.Write($"\t{i}");
				System.Console.WriteLine($") {_submenuOptions[i]}");
			}
			System.Console.WriteLine();
			System.Console.Write("Select an option from the menu: ");
			_selectedSubmenuOption = Convert.ToInt32(Console.ReadLine());

			System.Console.Clear();
			switch ((SubmenuOptions)_selectedSubmenuOption)
			{
				case SubmenuOptions.DisplayCatalog: // 1
					DisplayCatalog();
					break;
				case SubmenuOptions.AddResource: // 2
					AddResource();
					break;
				case SubmenuOptions.ModifyResource: // 3
					ModifyResource();
					break;
				case SubmenuOptions.GoBack: // 4
					System.Console.WriteLine("Returning to main menu.");
					System.Console.WriteLine();
					return;
				default:
					throw new Exception("Something went wrong.");
			}
			Pause();
			_selectedSubmenuOption = 0;
		}
	}

	private void ModifyResource()
	{
		throw new NotImplementedException();
	}

	private void AddResource()
	{
		System.Console.WriteLine("ADD RESOURCE\n");
		ResourceType type = GetResourceType("Select resource type: ");
		ResourceCategory category = GetCategoryType("Select category: ");
		ResourceSubcategory subcategory = GetSubcategoryType("Select subcategory: ");
		System.Console.WriteLine("> Provide additional information.");
		var title = GetUserInput("Title: ");
		var author = GetUserInput("Author: ");

		switch (type)
		{
			case ResourceType.Physical:

				var physical = new PhysicalResource(type, category, subcategory, title, author);
				if (physical.ResourceCategory == ResourceCategory.Book)
				{
					physical.Isbn = GetUserInput("ISBN (example: 978-3-16-148410-0): ");
				}
				_resources.Add(physical);
				break;
			case ResourceType.Digital:
				_resources.Add(new DigitalResource(type, category, subcategory, title, author));
				break;
			default:
				throw new Exception("Something went wrong");
		}
		System.Console.WriteLine();
		System.Console.WriteLine($"> New resource created");
		System.Console.WriteLine();
		System.Console.WriteLine("Resource description:");

		// TODO add full description of user data
		System.Console.WriteLine(_resources.Last().ToString());
		System.Console.WriteLine();
	}

	private ResourceType GetResourceType(string text)
	{
		System.Console.WriteLine($"> {text}");
		int i = 1;
		foreach (var userType in Enum.GetValues(typeof(ResourceType)))
		{
			Console.WriteLine($"{i++}) {userType}");
		}
		System.Console.Write("Selection: ");
		int selection = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine();
		switch (selection)
		{
			case 1:
				return ResourceType.Physical;
			case 2:
				return ResourceType.Digital;
			default:
				System.Console.WriteLine("No option available. Try again.\n");
				return GetResourceType(text);
		}
	}

	private ResourceCategory GetCategoryType(string text)
	{
		System.Console.WriteLine($"> {text}");
		int i = 1;
		foreach (var categoryType in Enum.GetValues(typeof(ResourceCategory)))
		{
			Console.WriteLine($"{i++}) {categoryType}");
		}
		System.Console.Write("Selection: ");
		int selection = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine();
		switch (selection)
		{
			case 1:
				return ResourceCategory.Book;
			case 2:
				return ResourceCategory.Journal;
			case 3:
				return ResourceCategory.Newspaper;
			case 4:
				return ResourceCategory.Illustration;
			case 5:
				return ResourceCategory.Graphics;
			default:
				System.Console.WriteLine("No option available. Try again.\n");
				return GetCategoryType(text);
		}
	}


	private ResourceSubcategory GetSubcategoryType(string text)
	{
		System.Console.WriteLine($"> {text}");
		int i = 1;
		foreach (var subcategoryType in Enum.GetValues(typeof(ResourceSubcategory)))
		{
			Console.WriteLine($"{i++}) {subcategoryType}");
		}
		System.Console.Write("Selection: ");
		int selection = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine();
		switch (selection)
		{
			case 1:
				return ResourceSubcategory.Academic;
			case 2:
				return ResourceSubcategory.Children;
			case 3:
				return ResourceSubcategory.Teenagers;
			case 4:
				return ResourceSubcategory.News;
			case 5:
				return ResourceSubcategory.Government;
			case 6:
				return ResourceSubcategory.Science;
			case 7:
				return ResourceSubcategory.Primary;
			case 8:
				return ResourceSubcategory.Scholar;
			case 9:
				return ResourceSubcategory.Literature;
			default:
				System.Console.WriteLine("No option available. Try again.\n");
				return GetSubcategoryType(text);
		}
	}

	private void UpdateResource()
	{
		System.Console.WriteLine("UPDATE RESOURCE\n");

		System.Console.WriteLine("Options:");



	}

	public void DisplayCatalog()
	{
		System.Console.WriteLine("DISPLAY CATALOG\n");

		int i = 1;
		foreach (var resource in _resources)
		{
			System.Console.WriteLine($">> Item {i++} <<");
			System.Console.WriteLine(resource.ToString());
			System.Console.WriteLine();
		}
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
		System.Console.WriteLine("Good bye.");
		System.Console.WriteLine();
	}
}