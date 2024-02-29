using System.Diagnostics.CodeAnalysis;

public class ActivityReflection : Activity
{
	private List<string> _prompts;
	private List<string> _questions;

	private Random _random = new Random();

	public ActivityReflection()
	{
		Name = "Reflection";
		Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
		_prompts = new List<string>()
		{
			"Think of a time when you stood up for someone else.",
			"Think of a time when you did something really difficult.",
			"Think of a time when you helped someone in need.",
			"Think of a time when you did something truly selfless.",
		};
		_questions = new List<string>()
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
	}

	public override void Start()
	{
		System.Console.WriteLine();
		System.Console.WriteLine("> Consider the following prompt:");
		System.Console.WriteLine();
		DisplayText(TextType.Prompt);
		System.Console.WriteLine();
		System.Console.WriteLine(">> When you have something in mind, press enter to continue.");
		// Keep looping until the Enter key is pressed
		while (Console.ReadKey().Key != ConsoleKey.Enter)
		{
			Console.WriteLine("\nInvalid key pressed. Please press Enter to continue...");
		}
		System.Console.WriteLine("> Now ponder in each of the following questions as they are related to this experience.");

		base.Start();

		while (IsRunning())
		{
			DisplayText(TextType.Question);
			ShowTimer(10, TimerMode.Seconds);
		}

		System.Console.WriteLine();
		base.End();
	}

	private void DisplayText(TextType textType)
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
}

public enum TextType
{
	Prompt,
	Question
}