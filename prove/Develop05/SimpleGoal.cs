using System.Text;

public class SimpleGoal : Goal
{
	string _deadLine = DateTime.Now.ToString("MM/dd/yy");
	public SimpleGoal(string name, string description, int basePoints)
	: base(name, description, basePoints)
	{
		GoalType = GoalTypes.SimpleGoal;
	}
	public SimpleGoal(string[] content)
	: base(content[0], content[1], Convert.ToInt32(content[2]))
	{
		GoalType = GoalTypes.SimpleGoal;
		Completed = Convert.ToBoolean(content[3]);
		_deadLine = content[4];
	}

	public override void SetUp()
	{
		System.Console.Write("What is the deadline you want for this goal? (Use format: mm/dd/yy) ");
		_deadLine = Console.ReadLine();
		base.SetUp();
	}
	public override string Describe(bool fullView)
	{
		var stringBuilder = new StringBuilder(base.Describe(fullView));
		if (fullView)
		{
			var additionalDescription = $" -- Deadline: {_deadLine}";
			stringBuilder.Append(additionalDescription);
		}
		return stringBuilder.ToString();
	}
	public override string ToString()
	{
		var stringBuilder = new StringBuilder(base.ToString());
		var isCompleted = Completed.ToString();
		stringBuilder.Append(",");
		stringBuilder.Append(isCompleted);
		stringBuilder.Append(",");
		stringBuilder.Append(_deadLine);
		return stringBuilder.ToString();
	}

	public override int GetPoints()
	{
		if (!Completed)
		{
			Completed = true;
			return base.GetPoints();
		}
		return 0;
	}
}