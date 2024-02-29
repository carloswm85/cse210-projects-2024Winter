

using System.Data.Common;

public class Activity
{
	protected string _name;
	protected string _description;
	protected int _duration;
	DateTime _activityEnd;
	private bool _running = true;
	private List<string> _animationSpinner = new List<string> { "|", "/", "-", "\\" };


	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	public string Description
	{
		get { return _description; }
		set { _description = value; }
	}

	public bool IsRunning()
	{
		return DateTime.Now < _activityEnd;
	}
	public void IsRunning(bool isRunning)
	{
		_running = isRunning;
	}
	private void SetDuration(int duration)
	{
		_duration = duration;
		_activityEnd = DateTime.Now.AddSeconds(_duration);
		IsRunning(true);
	}

	internal virtual void Describe()
	{
		System.Console.WriteLine();
		System.Console.WriteLine($">> Welcome to {Name} Activity");
		System.Console.WriteLine($"> {Description}");
	}

	internal void SetDuration()
	{
		System.Console.WriteLine();
		System.Console.Write(">> How long, in seconds, would you like for your session (suggested: 60 secs)? ");
		int duration = Convert.ToInt32(Console.ReadLine());
		System.Console.WriteLine($"> You have selected: {duration} seconds");
		SetDuration(duration);
	}
	public virtual void Start()
	{
		System.Console.WriteLine();
		System.Console.WriteLine($"> This activity will last approximately {_duration} seconds.");
		System.Console.Write(">> Get ready... ");
		ShowTimer(5, TimerMode.Seconds);
		System.Console.WriteLine("Start - " + DateTime.Now.ToString("HH:mm:ss"));
		System.Console.WriteLine();
	}

	internal void Pause()
	{
		System.Console.WriteLine();
		// System.Console.Write("Pause... ");
		ShowTimer(5, TimerMode.Spinner);
	}

	public void ShowTimer(int duration, TimerMode mode)
	{
		DateTime timerDuration = DateTime.Now.AddSeconds(duration);
		
		switch (mode)
		{
			case TimerMode.Spinner:
				int i = 0;
				while (DateTime.Now < timerDuration)
				{
					System.Console.Write(_animationSpinner[i]);
					Thread.Sleep(1000);
					System.Console.Write("\b \b");
					i++;
					if (i >= _animationSpinner.Count) i = 0;
				}
				break;
			case TimerMode.Seconds:
				while (DateTime.Now < timerDuration)
				{
					for (int j = duration; j > 0; j--)
					{
						System.Console.Write(j);
						Thread.Sleep(1000);
						if (j > 9) System.Console.Write("\b\b  \b");
						else System.Console.Write("\b \b");
					}
				}
				System.Console.WriteLine("\\");
				break;
			default:
				System.Console.WriteLine("Something went wrong.");
				break;
		}
	}

	internal void End()
	{
		System.Console.WriteLine("Well done!");
		System.Console.WriteLine($"You have completed {_duration} seconds of {Name} Activity.");
		System.Console.WriteLine("End - " + DateTime.Now.ToString("HH:mm:ss"));
		System.Console.WriteLine();
		System.Console.Write(">> Going back to the menu... ");
		ShowTimer(6, TimerMode.Spinner);
		Console.Clear();
	}
}

public enum TimerMode
{
	Spinner, // 0
	Seconds, // 1
	Minutes, // 2
	Hours, // 3
}