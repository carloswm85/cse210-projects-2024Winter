public class Activity
{

	private int _duration;
	protected string _name;
	protected string _description;
	private string _messageStart;
	private string _messageEnd;

	public Activity(int duration)
	{
		_duration = duration;
	}

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
}