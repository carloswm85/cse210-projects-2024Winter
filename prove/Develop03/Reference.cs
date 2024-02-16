public class Reference
{
	private string _book;
	private string _chapter;
	private string _startVerse;
	private string _endVerse;

	public Reference(string book, int chapter, int start, int? end = null)
	{
		_book = book;
		_chapter = chapter.ToString();
		_startVerse = start.ToString();
		_endVerse = end.ToString() ?? "";
	}

	public void RenderReference()
	{
		if (_endVerse == "")
		{
			Console.WriteLine($"$ {_book} {_chapter}:{_startVerse}");
			return;
		}
		Console.WriteLine($"$ {_book} {_chapter}:{_startVerse}-{_endVerse}");
	}

}