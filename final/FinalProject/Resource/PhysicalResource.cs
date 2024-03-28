class PhysicalResource : Resource
{
	private string _isbn;
	public string Isbn {
		get { return _isbn; }
		set { _isbn = value; }
	}

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
			resourceType, 
			resourceCategory, 
			resourceSubcategory,
			title, 
			author)
	{
	}

	public override string ToString()
	{
		string informationOne = $"ISBN: {_isbn}";
		string informationTwo = $"Reserved: {_isReserved} - Returned: {_isReturned} - Renewed: {_isRenewed}";
		return informationOne + "\n" + informationTwo;
	}
}