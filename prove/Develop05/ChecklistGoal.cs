using System.Text;

public class ChecklistGoal : Goal
{
	// Private Fields
	private int _bonusPoints;
	private int _currentChecks = 0;
	private int _targetChecks;

	// Public Properties
	public int BonusPoints
	{
		get { return _bonusPoints; }
		set { _bonusPoints = value; }
	}
	public int CurrentChecks
	{
		get { return _currentChecks; }
		set { _currentChecks = value; }
	}
	public int TargetCheck
	{
		get { return _targetChecks; }
		set { _targetChecks = value; }
	}

	// CTOR
	public ChecklistGoal(string name, string description, int basePoints)
	: base(name, description, basePoints)
	{
		GoalType = GoalTypes.ChecklistGoal;
	}

	// Public Methods
	public override void SetUp()
	{
		System.Console.Write("How many times does this goal need to be accomplished for a bonus? ");
		_targetChecks = Convert.ToInt32(Console.ReadLine());
		System.Console.Write("What is the bonus of accomplishing it that many times? ");
		_bonusPoints = Convert.ToInt32(Console.ReadLine());
		base.SetUp();
	}

	public override string Describe()
	{
		var stringBuilder = new StringBuilder(base.Describe());
		var additionalDescription = $" -- Currently completed: {_currentChecks}/{_targetChecks}";
		stringBuilder.Append(additionalDescription);
		return stringBuilder.ToString();
	}
	public override string ToString()
	{
		var stringBuilder = new StringBuilder(base.ToString());
		var additionalDescription = $",{_bonusPoints},{_targetChecks},{_currentChecks}";
		stringBuilder.Append(additionalDescription);
		return stringBuilder.ToString();
	}
}