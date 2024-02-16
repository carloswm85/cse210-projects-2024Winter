using System.Text.RegularExpressions;

public class Word
{
	private string _word;
	private string _keptWordValue;
	private bool _isVisible;
	private WordType _type;

	public Word(string word, WordType type, bool visibility)
	{
		_word = word;
		_keptWordValue = word;
		_type = type;
		_isVisible = visibility;
	}

	public string GetWord()
	{
		return _word;
	}
	public WordType GetWordType()
	{
		return _type;
	}

	public bool HideWord()
	{
		if (_isVisible)
		{
			_isVisible = !_isVisible;
			_word = new Regex("\\S").Replace(_word, "_");

		}
		return _isVisible;
	}
	public bool IsVisible()
	{
		return _isVisible;
	}
	public void RenderWord()
	{
		Console.Write($"{_word}");
	}
}

public enum WordType
{
	Word,
	SpecialCharacter
}