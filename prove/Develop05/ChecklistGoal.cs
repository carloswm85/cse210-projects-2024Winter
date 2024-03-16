using System.Text;

public class ChecklistGoal : Goal
{
	// Private Fields
	private int _bonusPoints;
	private int _currentChecks = 0;
	private int _targetChecks;

	// CTOR
	public ChecklistGoal(string name, string description, int basePoints)
	: base(name, description, basePoints)
	{
		GoalType = GoalTypes.ChecklistGoal;
	}
	public ChecklistGoal(string[] content)
		: base(content[0], content[1], Convert.ToInt32(content[2]))
	{
		GoalType = GoalTypes.ChecklistGoal;
		_bonusPoints = Convert.ToInt32(content[3]);
		_targetChecks = Convert.ToInt32(content[4]);
		_currentChecks = Convert.ToInt32(content[5]);
		if (_currentChecks == _targetChecks) {
			Completed = true;
		}
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

	public override string Describe(bool fullView)
	{
		var stringBuilder = new StringBuilder(base.Describe(fullView));
		if (fullView)
		{
			var additionalDescription = $" -- Currently completed: {_currentChecks}/{_targetChecks}";
			stringBuilder.Append(additionalDescription);
		}
		return stringBuilder.ToString();
	}
	public override string ToString()
	{
		var stringBuilder = new StringBuilder(base.ToString());
		var additionalDescription = $",{_bonusPoints},{_targetChecks},{_currentChecks}";
		stringBuilder.Append(additionalDescription);
		return stringBuilder.ToString();
	}

	public override int GetPoints()
	{
		_currentChecks++;
		if(_currentChecks == _targetChecks) {
			Completed = true;
			System.Console.WriteLine($"You have received {_bonusPoints} bonus points.");
			return base.GetPoints() + _bonusPoints;
		}
		if (!Completed){
			return base.GetPoints();
		}
		return 0;
	}
}