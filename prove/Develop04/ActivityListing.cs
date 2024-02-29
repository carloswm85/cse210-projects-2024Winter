public class ActivityListing : Activity
{
	private List<string> _questions;

	public ActivityListing()
	{
		Name = "Listing";
		Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
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
		System.Console.WriteLine("> List as many responses as you can to the following promp:");
		System.Console.WriteLine();
		System.Console.Write("\t>");
		DisplayText(TextType.Question);
		System.Console.Write("<<");
		System.Console.WriteLine();
		base.Start();
		List<string> answers = new();

		while (IsRunning())
		{
			System.Console.Write("> ");
			string answer = System.Console.ReadLine();
			answers.Add(answer);
		}
		System.Console.WriteLine();
		string s = answers.Count == 1 ? $"" : "s";
		System.Console.WriteLine($"You listed {answers.Count} item{s}!");
		System.Console.WriteLine();

		base.End();
	}
}