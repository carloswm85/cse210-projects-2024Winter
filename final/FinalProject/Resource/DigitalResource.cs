class DigitalResource : Resource
{
	private bool _isOnline;
	public bool IsOnline
	{
		get { return _isOnline; }
		set { _isOnline = value; }
	}

	private bool _isOpensource;
	public bool IsOpensource {
		get { return _isOpensource; }
		set { _isOpensource = value; }
	}

	private bool _isPaid;
	public bool IsPaid {
		get { return _isPaid; }
		set { _isPaid = value; }
	}

	public DigitalResource(
		string title,
		string author,
		ResourceType resourceType,
		ResourceCategory resourceCategory,
		ResourceSubcategory resourceSubcategory
		) : base(
			resourceType,
			resourceCategory,
			resourceSubcategory,
			title,
			author
			)
	{
		
	}

	public override string ToString()
	{
		string informationOne = $"Online: {_isOnline} - Opensource: {_isOpensource} - Paid: {_isPaid}";
		return informationOne;
	}
}