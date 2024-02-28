public class Menu
{
	private bool _running;
	private List<Activity> _activities;

	// Constructor
	public Menu(List<Activity> activities)
	{
		_running = true;
		_activities = activities;
	}

	public bool IsRunning(bool isRunning = true)
	{
		_running = isRunning;
		return _running;
	}

	// Methods
	public void ShowMenu()
	{
		int count = 0;
		System.Console.WriteLine("Menu Options:");
		
		foreach (var activity in _activities)
		{
			count++;
			System.Console.WriteLine(
				$"\t{count}. Start {activity.Name} activity"
			);
		}
	}

	internal void SelectActivity()
	{
		int selection = Convert.ToInt32(Console.ReadLine());


	}


	public void PromptDuration()
	{
		throw new NotImplementedException("This method is not implemented yet.");
	}

	public void End()
	{
		throw new NotImplementedException("This method is not implemented yet.");
	}

	public void Pause()
	{
		throw new NotImplementedException("This method is not implemented yet.");
	}

	public void Complete()
	{
		throw new NotImplementedException("This method is not implemented yet.");
	}

	public void Finish()
	{
		throw new NotImplementedException("This method is not implemented yet.");
	}

	public void ShowSpinner()
	{
		throw new NotImplementedException("This method is not implemented yet.");
	}


}
