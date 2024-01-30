public class Entry
{
	public string _prompt {get; set;}
	public string _response {get; set;}
	public string _date {get; set;}

	public void Display()
	{
		System.Console.WriteLine($"Date: {_date}");
		System.Console.WriteLine($"Prompt: {_prompt}");
		System.Console.WriteLine($"Response: {_response}");
		System.Console.WriteLine();
	}
}