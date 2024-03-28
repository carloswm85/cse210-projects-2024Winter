class Resource
{
	private Guid _id;
	public Guid Id
	{
		get { return _id; }
		set { _id = value; }
	}

	private string _title;
	public string Title
	{
		get { return _title; }
		set { _title = value; }
	}

	private string _author;
	public string Author
	{
		get { return _author; }
		set { _author = value; }
	}

	private ResourceType _resourceType;
	public ResourceType ResourceType
	{
		get { return _resourceType; }
		set { _resourceType = value; }
	}


	private ResourceCategory _resourceCategory;
	public ResourceCategory ResourceCategory
	{
		get { return _resourceCategory; }
		set { _resourceCategory = value; }
	}

	private ResourceSubcategory _resourceSubcategory;
	public ResourceSubcategory ResourceSubcategory
	{
		get { return _resourceSubcategory; }
		set { _resourceSubcategory = value; }
	}

	private bool _isAvailable;

	public bool IsAvailable
	{
		get { return _isAvailable; }
		set { _isAvailable = value; }
	}

	public Resource(
		ResourceType resourceType,
		ResourceCategory resourceCategory,
		ResourceSubcategory resourceSubcategory,
		string title,
		string author
		)
	{
		_resourceType = resourceType;
		_resourceCategory = resourceCategory;
		_resourceSubcategory = resourceSubcategory;
		_title = title;
		_author = author;
	}

	public void ToggleStatus()
	{
		_isAvailable = !_isAvailable;
	}

	public override string ToString()
	{
		return $"Type: {_resourceType} - Title: {_title} - Author: {_author}";
	}
}