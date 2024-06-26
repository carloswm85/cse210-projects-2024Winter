class PhysicalResource : Resource
{
	private DateTime _dueDate;
	public DateTime DueDate {
		get { return _dueDate; }
		set { _dueDate = value; }
	}
	
	private bool _isReserved;
	public bool IsReserved {
		get { return _isReserved; }
		set { _isReserved = value; }
	}

	private bool _isRenewed;
	public bool IsRenewed {
		get { return _isRenewed; }
		set { _isRenewed = value; }
	}

	private bool _isReturned;
	public bool IsReturned {
		get { return _isReturned; }
		set { _isReturned = value; }
	}
		
	public PhysicalResource(
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
		_isbn = "NN";
		_isReserved = false;
		_isReturned = false;
		_isRenewed = false;
	}

	public PhysicalResource(string[] content)
: base(
		content[1],
		content[2],
		ResourceType.Physical,
		(ResourceCategory)Enum.Parse(typeof(ResourceCategory), content[3]),
		(ResourceSubcategory)Enum.Parse(typeof(ResourceSubcategory), content[4])
		)
	{
		_id = Guid.Parse(content[0]);
		_isbn = content[5];
		_isReserved = Convert.ToBoolean(content[6]);
		_isReturned = Convert.ToBoolean(content[7]);
		_isRenewed = Convert.ToBoolean(content[8]);
	}

	public override string ToString()
	{
		var dataFromBase = base.ToString();
		var line1 = $"- ISBN: {_isbn}\n";
		var line2 = $"- Reserved/Returned/Renewed: {_isReserved}/{_isReturned}/{_isRenewed}";
		return $"{dataFromBase}{line1}{line2}";
	}

	// Method to create a deep copy
	public override PhysicalResource DeepCopy()
	{
		return new PhysicalResource(
		 this.ResourceType,
		 this.ResourceCategory,
		 this.ResourceSubcategory,
		 this.Title,
		 this.Author
		) {
			_isbn = this._isbn,
			_isReserved = this._isReserved,
			_isReturned = this._isReturned,
			_isRenewed = this._isRenewed,
		};
	}

	public override string ToFile()
	{
		string baseInformation = base.ToFile();
		return $"{baseInformation},{_isbn},{_isReserved},{_isRenewed},{_isReturned}";
	}
}