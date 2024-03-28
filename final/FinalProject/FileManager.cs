public class FileManager
{
	// Class Public Methods
	public string[] Load(string fileName)
	{
		return System.IO.File.ReadAllLines(fileName);
	}
	public void Save(string fileName, List<string> lines, string firsLine)
	{
		using (StreamWriter outputFile = new StreamWriter(fileName))
		{
			outputFile.WriteLine(firsLine);
			foreach (var line in lines)
			{
				outputFile.WriteLine(line);
			}
		}
	}
}