public class Menu
{
	private bool _running;
	private int _selectedOption;
	private List<Activity> _activities;

	// Constructor
	public Menu(List<Activity> activities)
	{
		_running = true;
		_activities = activities;
	}

	public bool IsRunning()
	{
		return _running;
	}
	public void IsRunning(bool isRunning)
	{
		_running = isRunning;
	}

	// Methods
	public void ShowMenu()
	{
		int count = 1;
		System.Console.WriteLine("> Menu Options:");

		foreach (var activity in _activities)
		{
			System.Console.WriteLine(
				$"\t{count}. Start {activity.Name} activity"
			);
			count++;
		}
		System.Console.WriteLine(
			$"\t{count}. Quit"
		);
	}

	public Activity SelectActivity()
	{
		System.Console.WriteLine();
		System.Console.WriteLine("> Select a choice from the menu:");
		_selectedOption = Convert.ToInt32(Console.ReadLine());

		while(_selectedOption < 0 || _selectedOption > _activities.Count) {
			System.Console.WriteLine(">> Wrong selection. Try again.");
		}

		if (_selectedOption == 4)
		{
			IsRunning(false);
			System.Console.WriteLine(">> Program ended.");
			return null;
		}

		Console.Clear();
		System.Console.WriteLine($"> Selection was: {_selectedOption}");

		// ADJUST SELECTION TO REAL LIST INDEXING
		_selectedOption = _selectedOption - 1;
		return _activities[_selectedOption];	
	}

}
