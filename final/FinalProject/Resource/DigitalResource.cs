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
			title,
			author,
			resourceType,
			resourceCategory,
			resourceSubcategory
			)
	{
		_isOnline = true;
		_isOpensource = false;
		_isPaid = false;
	}

	public DigitalResource(string[] content)
: base(
		content[1],
		content[2],
		ResourceType.Digital,
		(ResourceCategory)Enum.Parse(typeof(ResourceCategory), content[3]),
		(ResourceSubcategory)Enum.Parse(typeof(ResourceSubcategory), content[4])
		)
	{
		_id = Guid.Parse(content[0]);
		_isOnline = Convert.ToBoolean(content[5]);
		_isOpensource = Convert.ToBoolean(content[6]);
		_isPaid = Convert.ToBoolean(content[7]);
	}

	public override string ToString()
	{
		var dataFromBase = base.ToString();
		var line1 = $"- Online/Opensource/Paid: {_isOnline}/{_isOpensource}/{_isPaid}";
		return $"{dataFromBase}{line1}";
	}

	// Method to create a deep copy
	public override DigitalResource DeepCopy()
	{
		return new DigitalResource(
		 this.ResourceType,
		 this.ResourceCategory,
		 this.ResourceSubcategory,
		 this.Title,
		 this.Author
		)
		{
			_isOnline = this._isOnline,
			_isOpensource = this._isOpensource,
			_isPaid = this._isPaid,
		};
	}

	public override string ToFile()
	{
		string baseInformation = base.ToFile();
		return $"{baseInformation},{_isOnline},{_isOpensource},{_isPaid}";
	}
}