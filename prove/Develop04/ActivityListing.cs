public class ActivityListing : Activity
{

	public ActivityListing()
	{
		Name = "Listing";
		Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
	}

	public override void Start()
	{
		base.Start();

		while (IsRunning())
		{
			System.Console.Write("Listing");
			// ShowTimer(5, TimerMode.Seconds);
			// System.Console.Write("Now breathe out... ");
			// ShowTimer(5, TimerMode.Seconds);
			// System.Console.WriteLine();
			// Pause();
		}

		base.End();
	}
}