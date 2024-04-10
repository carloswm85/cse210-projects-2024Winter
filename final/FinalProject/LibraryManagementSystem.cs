
using System.Runtime.InteropServices;

class LibraryManagementSystem
{
	private string _name;
	private int _selectedMenuOption;
	private int _selectedSubmenuOption;
	private List<string> _menuOptions;
	private List<string> _submenuOptions;
	private List<User> _users;

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
	private List<Resource> _resources;
    private string _fileName;

    public LibraryManagementSystem(string libraryName, FileManager fileManager)
	{
		_name = libraryName;
		_fileManager = fileManager;
		_menuOptions = new List<string> {
			"0 INDEX IS NULL",
			"Log in",
			"Log out",
			"Register new user",
			"Search users",
			"Resource manager (physical and digital)",
			"Your profile information",
			"Quit program",
		};
		_submenuOptions = new List<string> {
			"0 INDEX IS NULL",
			"Display resource catalog",
			"Add new resource",
			"Modify resource (update or delete)",
			"Load from file",
			"Save to file",
			"Go back to main menu"
		};
		_users = new List<User>() {
			new Staff("admin", "Staff", "Administrator", "admin@library.org", "Admin123", UserType.Staff, StaffType.Admin),
			new Member("user", "Member", "Student", "admin@library.org", "Student123", UserType.Staff, MemberType.Student),
		};
		_resources = new List<Resource>() {
			new PhysicalResource(ResourceType.Physical, ResourceCategory.Book,ResourceSubcategory.Literature, "The Lord of the Rings", "J. R. R. Tolkien") {
				Isbn = "9780544003415",
			},
			new DigitalResource(ResourceType.Digital, ResourceCategory.Book,ResourceSubcategory.Academic, "Another Digital Book", "John D. Doe")
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
		System.Console.WriteLine("User & Password: admin, Admin123");
		System.Console.WriteLine("User & Password: user, Student123");
		System.Console.WriteLine("------------------------------------");
		System.Console.WriteLine();
		System.Console.WriteLine($">> {_name} <<");
		System.Console.WriteLine();
		System.Console.WriteLine("Menu Options:");
		for (int i = 1; i < _menuOptions.Count; i++)
		{
			System.Console.Write($"\t{i}");
			System.Console.WriteLine($") {_menuOptions[i]}");
		}
		System.Console.WriteLine();
		_selectedMenuOption = SelectOption("Select an option from the menu:");

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


	private void ResourceManager()
	{
		if (_user == null)
		{
			System.Console.WriteLine("> There is no user logged in.");
			System.Console.WriteLine();
			return;
		}

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
			_selectedSubmenuOption = SelectOption("Select an option from the menu:");

			System.Console.Clear();
			switch ((SubmenuOptions)_selectedSubmenuOption)
			{
				case SubmenuOptions.DisplayCatalog: // 1
					DisplayCatalog(true);
					break;
				case SubmenuOptions.AddResource: // 2
					AddResource();
					break;
				case SubmenuOptions.ModifyResource: // 3
					ModifyResource();
					break;
				case SubmenuOptions.LoadFile: // 6
					LoadFile();
					break;
				case SubmenuOptions.SaveFile: // 7
					SaveFile();
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
	private void SaveFile()
	{
		if (_user == null)
		{
			System.Console.WriteLine("> There is no user logged in.");
			System.Console.WriteLine();
			return;
		}

		if (_resources.Count == 0)
		{
			Console.Clear();
			System.Console.WriteLine("> There is no information to save.");
			Pause();
			return;
		}

		System.Console.Write("What is the filename for the file? ");
		_fileName = Console.ReadLine();
		var resourcesString = new List<string>();

		foreach (Resource resource in _resources)
		{
			resourcesString.Add(resource.ToFile());
		}

		_fileManager.Save(_fileName, resourcesString, "-- RESOURCES --");
		System.Console.WriteLine();
		System.Console.WriteLine("> Information has been saved.");
		System.Console.WriteLine();
	}

	private void LoadFile()
	{
		Console.Clear();
		System.Console.WriteLine(">> LOADING INFORMATION FROM FILE <<");
		System.Console.WriteLine();
		_fileName = GetUserInput("What is the filename?");
		System.Console.WriteLine();
		var content = _fileManager.Load(_fileName);
		content = content.Skip(1).ToArray();

		foreach (string line in content)
		{
			string[] parts = line.Split(":");
			string header = parts[0];
			string body = parts[1];
			Resource resource = new();

			string[] bodyContent = body.Split(",");

			switch ((ResourceType)Enum.Parse(typeof(ResourceType), header))
			{
				case ResourceType.Physical:
					resource = new PhysicalResource(bodyContent);
					break;
				case ResourceType.Digital:
					resource = new DigitalResource(bodyContent);
					break;
				default:
					throw new Exception("Something went wrong.");
			}
			_resources.Add(resource);
		}
		System.Console.WriteLine("> File has been loaded to local memory.");
		System.Console.WriteLine();
	}

	private void UserProfile()
	{
		System.Console.WriteLine(">> PROFILE INFORMATION <<\n");

		if (_user == null)
		{
			System.Console.WriteLine("> There is no user logged in.");
			System.Console.WriteLine();
			return;
		}
			System.Console.WriteLine(_user.ToString());
	}

	public void LogIn()
	{
		System.Console.WriteLine("LOG IN\n");
		var username = GetUserInput("Enter username:");
		var password = GetUserInput("Enter password:");
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
		System.Console.WriteLine("REGISTER NEW USER");
		System.Console.WriteLine();
		var username = GetUserInput("Enter username:");
		var firstName = GetUserInput("Enter your first name:");
		var lastName = GetUserInput("Enter your last name:");
		var email = GetUserInput("Enter your email address:");
		var password = GetUserInput("Select your user password:");
		System.Console.WriteLine();
		var userType = GetUserType("Select user type: ");

		switch (userType)
		{
			case UserType.Member:
				var memberType = GetMemberType("Select member type: ");
				_users.Add(new Member(username, firstName, lastName, email, password, userType, memberType));
				break;
			case UserType.Staff:
				var staffType = GetStaffType("Select staff type: ");
				_users.Add(new Staff(username, firstName, lastName, email, password, userType, staffType));
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
		System.Console.Write($"{diplayedText} ");
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
		int selection = SelectOption("Selection:");
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
		int selection = SelectOption("Selection:");
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
		int selection = SelectOption("Selection:");
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
		var run = true;

		while (run)
		{
			Console.Clear();
			System.Console.WriteLine("USERS LIST\n");
			var username = GetUserInput("Search by username:");
			var user = _users.FirstOrDefault(u => u.Username == username);

			if (user != null)
			{
				System.Console.WriteLine("> User found. Public data.");
				System.Console.WriteLine();
				System.Console.WriteLine(user.ToString());
			}
			else
			{
				System.Console.WriteLine("User does not exist.");
				System.Console.WriteLine();
			}

			var answer = GetBooleanInput("> Do you want to search again? (Y/N)");
			if (!answer)
			{
				run = false;
				Console.Clear();
				System.Console.WriteLine("> Search cancelled by the user.");
				System.Console.WriteLine();
			}
		}
	}

	private bool GetBooleanInput(string text)
	{
		System.Console.Write($"{text} ");
		var answer = Console.ReadLine();
		if (answer == "N" || answer == "n")
		{
			return false;
		}
		if (answer == "Y" || answer == "y")
		{
			return true;
		}
		return GetBooleanInput(text);
	}

	private void ModifyResource()
	{
		System.Console.WriteLine("UPDATE/DELETE RESOURCE\n");

		DisplayCatalog(false);
		if (_resources.Count == 0 || _resources == null) return;

		var selectedResource = SelectOption("Select an item by number:");
		System.Console.WriteLine();
		var resource = _resources[selectedResource - 1];

		if (resource != null)
		{
			Console.Clear();
			System.Console.WriteLine($">> Selection: Item #{selectedResource}");
			System.Console.WriteLine(resource.ToString());
			System.Console.WriteLine();

			System.Console.WriteLine("> What do you want to do?");
			System.Console.WriteLine("1) Update item");
			System.Console.WriteLine("2) Delete item");
			var updateOrDelete = SelectOption("Selection:");
			System.Console.WriteLine();

			switch (updateOrDelete)
			{
				case 1:
					UpdateResource(_resources[selectedResource - 1]);
					break;
				case 2:
					_resources.RemoveAt(selectedResource - 1);
					System.Console.WriteLine("Item has been deleted.");
					break;
				default:
					throw new Exception("Something went wrong.");
			}
			System.Console.WriteLine();
		}

	}

	private int SelectOption(string text)
	{
		System.Console.Write($"> {text} ");
		return Convert.ToInt32(Console.ReadLine());
	}

	private void AddResource()
	{
		System.Console.WriteLine("ADD RESOURCE\n");
		ResourceType type = GetResourceType();
		ResourceCategory category = GetCategoryType();
		ResourceSubcategory subcategory = GetSubcategoryType();
		System.Console.WriteLine("> Provide additional information.");
		var title = GetUserInput("Title:");
		var author = GetUserInput("Author:");

		switch (type)
		{
			case ResourceType.Physical:

				var physical = new PhysicalResource(type, category, subcategory, title, author);
				if (physical.ResourceCategory == ResourceCategory.Book)
				{
					physical.Isbn = GetUserInput("ISBN (example: 978-3-16-148410-0):");
				}
				_resources.Add(physical);
				break;
			case ResourceType.Digital:
				var digital = new DigitalResource(type, category, subcategory, title, author)
				{
					IsOnline = GetBooleanInput("Is available online? (Y/N)"),
					IsOpensource = GetBooleanInput("Is open source? (Y/N)"),
					IsPaid = GetBooleanInput("Is it paid? (Y/N)")
				};
				_resources.Add(digital);
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

	private ResourceType GetResourceType()
	{
		System.Console.WriteLine("> Select resource type: ");
		int i = 1;
		foreach (var resourceType in Enum.GetValues(typeof(ResourceType)))
		{
			Console.WriteLine($"\t{i++}) {resourceType}");
		}
		int selection = SelectOption("Selection:");
		System.Console.WriteLine();
		switch (selection)
		{
			case 1:
				return ResourceType.Physical;
			case 2:
				return ResourceType.Digital;
			default:
				System.Console.WriteLine("No option available. Try again.\n");
				return GetResourceType();
		}
	}

	private ResourceCategory GetCategoryType()
	{
		System.Console.WriteLine("> Select category: ");
		int i = 1;
		foreach (var categoryType in Enum.GetValues(typeof(ResourceCategory)))
		{
			Console.WriteLine($"\t{i++}) {categoryType}");
		}
		int selection = SelectOption("Selection:");
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
				return GetCategoryType();
		}
	}

	private ResourceSubcategory GetSubcategoryType()
	{
		System.Console.WriteLine("> Select subcategory: ");
		int i = 1;
		foreach (var subcategoryType in Enum.GetValues(typeof(ResourceSubcategory)))
		{
			Console.WriteLine($"\t{i++}) {subcategoryType}");
		}
		int selection = SelectOption("Selection:");
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
				return GetSubcategoryType();
		}
	}

	private void UpdateResource(Resource resource)
	{
		Console.Clear();
		System.Console.WriteLine("UPDATE RESOURCE\n");
		Resource resourceOld;

		if (typeof(PhysicalResource) == resource.GetType())
		{
			PhysicalResource resourcePhy = resource as PhysicalResource;
			resourceOld = resourcePhy.DeepCopy();
		}
		else
		{
			DigitalResource resourceDig = resource as DigitalResource;
			resourceOld = resourceDig.DeepCopy();
		}

		System.Console.WriteLine(resource.ToString());
		System.Console.WriteLine();
		System.Console.WriteLine("UPDATE FIELDS");
		resource.Title = GetUserInput("> Title:");
		resource.Author = GetUserInput("> Author:");
		System.Console.WriteLine();
		resource.ResourceType = GetResourceType();
		resource.ResourceCategory = GetCategoryType();
		resource.ResourceSubcategory = GetSubcategoryType();

		if (resource is PhysicalResource)
		{
			if (resource.ResourceCategory == ResourceCategory.Book)
			{
				resource.Isbn = GetUserInput("> ISBN:");
			}
			PhysicalResource pr = resource as PhysicalResource;
			pr.IsReserved = GetBooleanInput("> Is reserved? (Y/N)");
			pr.IsReturned = GetBooleanInput("> Is returned? (Y/N)");
			pr.IsRenewed = GetBooleanInput("> Is renewed? (Y/N)");
		}

		if (resource is DigitalResource)
		{
			DigitalResource dr = resource as DigitalResource;
			dr.IsOnline = GetBooleanInput("Is available online? (Y/N)");
			dr.IsOpensource = GetBooleanInput("Is open source? (Y/N)");
			dr.IsPaid = GetBooleanInput("Is it paid? (Y/N)");
		};

		int index = _resources.FindIndex(item => item.Id == resource.Id);

		if (index != -1)
		{
			_resources[index] = resource;
		}
		else
		{
			Console.WriteLine($"Item with ID {resource.Id} not found.");
		}

		Console.Clear();
		System.Console.WriteLine("Update finished.");
		System.Console.WriteLine();
		System.Console.WriteLine(resourceOld.ToString());
		System.Console.WriteLine();
		System.Console.WriteLine(resource.ToString());
	}

	public void DisplayCatalog(bool addTitle)
	{
		if (addTitle)
		{
			System.Console.WriteLine("DISPLAY CATALOG\n");
		}

		if (_resources.Count == 0 || _resources == null)
		{
			System.Console.WriteLine("There are no items in the resource list.");
			System.Console.WriteLine();
			return;
		}

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
		System.Console.WriteLine();
	}
}