public class Goal
{
	// Private Variables
	private GoalTypes _type;
	private string _name;
	private string _description;
	private int _basePoints;
	public bool _completed = false;

	// Public Properties
	public bool Completed
	{
		get { return _completed; }
		set { _completed = value; }
	}
	public GoalTypes GoalType
	{
		get { return _type; }
		set { _type = value; }
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
	public int BasePoints
	{
		get { return _basePoints; }
		set { _basePoints = value; }
	}

	// CTOR
	public Goal() { }
	public Goal(string name, string description, int basePoints)
	{
		Name = name;
		Description = description;
		BasePoints = basePoints;
	}

	public virtual void SetUp()
	{
		System.Console.WriteLine("Congratulations, you have created a new goal.");
		System.Console.WriteLine(">> Press enter to continue <<");
		while (Console.ReadKey().Key != ConsoleKey.Enter) { }
	}
	public virtual string Describe(bool fullView)
	{
		if (fullView)
		{
			string status = " ";
			if (Completed) status = "X";
			if (_type.Equals(GoalTypes.EternalGoal)) status = "-";
			return $"[{status}] {Name} ({Description})";
		}
		return $"{Name}";
	}
	public override string ToString()
	{
		var goalType = Enum.GetName(typeof(GoalTypes), _type);
		return $"{goalType}:{_name},{_description},{_basePoints}";
	}

	public virtual int GetPoints()
	{
		return _basePoints;
	}
}