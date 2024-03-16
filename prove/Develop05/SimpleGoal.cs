using System.Text;

public class SimpleGoal : Goal
{
	string _deadLine = DateTime.Now.ToString("MM/dd/yy");
	public SimpleGoal(string name, string description, int basePoints)
	: base(name, description, basePoints)
	{
		GoalType = GoalTypes.SimpleGoal;
	}

	public override void SetUp()
	{
		System.Console.Write("What is the deadline you want for this goal? (Use format: mm/dd/yy) ");
		_deadLine = Console.ReadLine();
		base.SetUp();
	}
	public override string Describe()
	{
		var stringBuilder = new StringBuilder(base.Describe());
		var additionalDescription = $" -- Deadline: {_deadLine}";
		stringBuilder.Append(additionalDescription);
		return stringBuilder.ToString();
	}
	public override string ToString()
	{
		var stringBuilder = new StringBuilder(base.ToString());
		var isCompleted = _completed.ToString();
		stringBuilder.Append(",");
		stringBuilder.Append(isCompleted);
		stringBuilder.Append(",");
		stringBuilder.Append(_deadLine);
		return stringBuilder.ToString();
	}
}