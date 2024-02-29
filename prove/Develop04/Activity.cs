

using System.Data.Common;

public class Activity
{
	protected string _name;
	protected string _description;
	protected int _duration;
	DateTime _activityEnd;
	private bool _firstRun = false;
	private List<string> _animationSpinner = new List<string> { "|", "/", "-", "\\" };
	private List<string> _prompts = new List<string>()
		{
			"Think of a time when you stood up for someone else.",
			"Think of a time when you did something really difficult.",
			"Think of a time when you helped someone in need.",
			"Think of a time when you did something truly selfless.",
		};
	private List<string> _questions = new List<string>()
		{
			"Why was this experience meaningful to you?",
			"Have you ever done anything like this before?",
			"How did you get started?",
			"How did you feel when it was complete?",
			"What made this time different than other times when you were not as successful?",
			"What is your favorite thing about this experience?",
			"What could you learn from this experience that applies to other situations?",
			"What did you learn about yourself through this experience?",
			"How can you keep this experience in mind in the future?",
		};
	private Random _random = new Random();


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
		if (_firstRun)
		{
			_firstRun = false;
			return true;
		}
		return DateTime.Now < _activityEnd;
	}
	public void IsFirstRun(bool firstRun)
	{
		_firstRun = firstRun;
	}
	private void SetDuration(int duration)
	{
		_duration = duration;
		IsFirstRun(true);
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
		_activityEnd = DateTime.Now.AddSeconds(_duration);
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

	protected void DisplayText(TextType textType)
	{
		switch (textType)
		{
			case TextType.Prompt:
				System.Console.Write("\t~ ");
				int promptIndex = _random.Next(_prompts.Count);
				System.Console.Write(_prompts[promptIndex]);
				System.Console.WriteLine(" ~");
				break;
			case TextType.Question:
				int questionIndex = _random.Next(_questions.Count);
				System.Console.Write("> " + _questions[questionIndex] + " ");
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
}