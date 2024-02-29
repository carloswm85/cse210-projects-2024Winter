using System.Diagnostics.CodeAnalysis;

public class ActivityReflection : Activity
{
	public ActivityReflection()
	{
		Name = "Reflection";
		Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
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
}

public enum TextType
{
	Prompt,
	Question
}