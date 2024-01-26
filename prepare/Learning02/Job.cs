public class Job {
	// 	Attributes:
	// * _company : string
	// * _title : string
	// * _yearEnd : DateTime || int
	// * _yearStart : DateTime || int
	// Behaviors:
	// * Display() : void  // "Job Title (Company) StartYear-EndYear"

	public string _company;
	public string _jobTitle;
	public int  _yearEnd;
	public int  _yearStart;

	public void Display() {
		Console.WriteLine($"{_jobTitle} ({_company}) {_yearStart}-{_yearEnd}");
	}
}