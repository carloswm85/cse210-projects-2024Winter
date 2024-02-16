public class MenuOptions
{
	private int _amountWords;
	private int _amountVerses;

	public MenuOptions(int amountWords, int amountVerses) {
		_amountWords = amountWords;
		_amountVerses = amountVerses;
	}

	public int AmountWords
	{
		get { return _amountWords; }
	}

	public int AmountVerses
	{
		get { return _amountVerses; }
	}
}

