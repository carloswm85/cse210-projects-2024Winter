using System.Data;

public class ActivityBreathing : Activity
{
	private List<string> _animation = new List<string> { "|", "/", "-", "\\" };
	public ActivityBreathing()
	{
		Name = "Breathing";
		Description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
	}

	public override void Start()
	{
		base.Start();

		while (IsRunning()) {
			System.Console.Write("Breathe in... ");
			ShowTimer(5, TimerMode.Seconds);
			System.Console.Write("Now breathe out... ");
			ShowTimer(5, TimerMode.Seconds);
			System.Console.WriteLine();
			// Pause();
		}
		
		base.End();
	}
}