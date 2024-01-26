// ```cs
// CLASS: Resume
// Attributes:
// * _name : string
// * _jobs : List<Job>
// Behaviors:
// *Display() : void  // "Name, List of jobs"
// ```

public class Resume {
	public string _namePerson;
	public List<Job> _jobs = new List<Job>();

	public void Display() {
		Console.WriteLine($"Name: {_namePerson}");
		Console.WriteLine("Jobs:");
		foreach (var job in _jobs)
		{
			job.Display();
		}
	}
}