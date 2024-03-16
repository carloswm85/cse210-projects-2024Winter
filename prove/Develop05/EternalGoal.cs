
using System.Text;

public class EternalGoal : Goal
{
    // Private Fields
    private int _completedTimes;

    // Public Properties
    public int CompletedTimes
    {
        get { return _completedTimes; }
        set { _completedTimes = value; }
    }

    // CTOR    
    public EternalGoal(string name, string description, int basePoints)
    : base(name, description, basePoints)
    {
        GoalType = GoalTypes.EternalGoal;
    }

    // Public Methods
    public override void SetUp()
    {
        base.SetUp();
    }

    public override string Describe()
    {
        var stringBuilder = new StringBuilder(base.Describe());
        var additionalDescription = $" -- Completed times: {_completedTimes}";
        stringBuilder.Append(additionalDescription);
        return stringBuilder.ToString();
    }
    public override string ToString()
    {
        var stringBuilder = new StringBuilder(base.ToString());
        var additionalDescription = $",{_completedTimes}";
        stringBuilder.Append(additionalDescription);
        return stringBuilder.ToString();
    }
}