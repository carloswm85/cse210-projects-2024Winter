
using System.Text;

public class EternalGoal : Goal
{
    // Private Fields
    private int _completedTimes;

    // CTOR    
    public EternalGoal(string name, string description, int basePoints)
    : base(name, description, basePoints)
    {
        GoalType = GoalTypes.EternalGoal;
    }
    public EternalGoal(string[] content)
    : base(content[0], content[1], Convert.ToInt32(content[2]))
    {
        GoalType = GoalTypes.EternalGoal;
        _completedTimes = Convert.ToInt32(content[3]);
    }

    // Public Methods
    public override void SetUp()
    {
        base.SetUp();
    }

    public override string Describe(bool fullView)
    {
        var stringBuilder = new StringBuilder(base.Describe(fullView));
        if (fullView)
        {
            var additionalDescription = $" -- Completed times: {_completedTimes}";
            stringBuilder.Append(additionalDescription);
        }
        return stringBuilder.ToString();
    }
    public override string ToString()
    {
        var stringBuilder = new StringBuilder(base.ToString());
        var additionalDescription = $",{_completedTimes}";
        stringBuilder.Append(additionalDescription);
        return stringBuilder.ToString();
    }
    public override int GetPoints()
    {
        _completedTimes++;
        return base.GetPoints();
    }
}