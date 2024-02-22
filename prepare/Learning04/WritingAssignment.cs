public class WritingAssignment : Assignment
{

	private string _title;

	public WritingAssignment(string title, string studentName, string topic)
		: base(studentName, topic)
	{
		_title = title;
	}

	public string GetWritingInformation()
	{
		// var studentName = GetStudentName(); // Use in case this member variable is private
		return $"{_title} by {_studentName}";
	}

}