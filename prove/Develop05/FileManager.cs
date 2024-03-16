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
	public string[] Load(string fileName)
	{
		return System.IO.File.ReadAllLines(fileName);		
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