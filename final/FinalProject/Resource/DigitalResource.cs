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
		ResourceType resourceType,
		ResourceCategory resourceCategory,
		ResourceSubcategory resourceSubcategory,
		string title,
		string author
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
		var dataFromBase = base.ToString();
		var line1 = $"- Online/Opensource/Paid: {_isOnline}/{_isOpensource}/{_isPaid}";
		return $"{dataFromBase}{line1}";
	}
}