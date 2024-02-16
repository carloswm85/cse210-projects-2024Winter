
using System.Net.Mime;
using System.Text.RegularExpressions;

public class Scripture
{
	private Reference _reference;
	private List<Word> _content;
	private int _visibleWordsCount;
	public Scripture(Reference reference, string content)
	{
		_reference = reference;
		var list = new List<string> { content };
		_content = GenerateWordList(list);
		_visibleWordsCount = _content.Where(e => e.IsVisible() == true).Count();
	}
	public Scripture(Reference reference, List<string> content)
	{
		_reference = reference;
		_content = GenerateWordList(content);
		_visibleWordsCount = _content.Where(e => e.IsVisible() == true).Count();
	}

	public bool VisibleWords() {
		if (_visibleWordsCount != 0) return true;
		return false;
	}

	public void HideWords()
	{
		Random rnd = new Random();

			int index = rnd.Next(_content.Count);

			var item = _content[index];
			var isVisible = item.IsVisible();

			if (isVisible) {
				item.HideWord();
				_visibleWordsCount = _visibleWordsCount - 1;
				return;
			} else {
				this.HideWords();
			}
	}

	public void RenderScripture()
	{
		System.Console.WriteLine();
		_reference.RenderReference();
		foreach (var word in _content)
		{
			word.RenderWord();
		}
		System.Console.WriteLine();
	}

	// PRIVATE METHODS
	private List<Word> GenerateWordList(List<string> content)
	{
		List<Word> wordsList = new List<Word>();
		foreach (var sentence in content)
		{
			wordsList.Add(new Word("\n", WordType.SpecialCharacter, false));
			wordsList.Add(new Word("~ ", WordType.SpecialCharacter, false));

			// Extract words and special characters
			MatchCollection matches = Regex.Matches(sentence, @"\b\w+\b|[\W]");

			foreach (Match match in matches)
			{
				var wordValue = match.Value;
				var type = char.IsLetter(match.Value[0]) ? WordType.Word : WordType.SpecialCharacter;
				var visibility = type == WordType.Word ? true : false;
				var word = new Word(wordValue, type, visibility);
				wordsList.Add(word);
			}
		}

		return wordsList;
	}
}