public class FileManager
{
	// Private Fields
	private string _fileName;
	private string[] _content;

	// Public Properties
	public string FileName
	{
		get { return _fileName; }
		set { _fileName = value; }
	}
	public string[] Content
	{
		get { return _content; }
		set { _content = value; }
	}

	// Class Methods	
	public void Load(string fileName)
	{
		string[] lines = System.IO.File.ReadAllLines(fileName);

		foreach (string line in lines)
		{
			string[] parts = line.Split(",");

			string firstName = parts[0];
			string lastName = parts[1];
		}
	}
	public void Save(string fileName, List<string> list, string header)
	{
		using (StreamWriter outputFile = new StreamWriter(fileName))
		{
			outputFile.WriteLine(header);
			foreach (var item in list)
			{
				outputFile.WriteLine(item);
			}
		}
	}
}