class Resource
{
	protected Guid _id;
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

	protected string _isbn;
	public string Isbn
	{
		get { return _isbn; }
		set { _isbn = value; }
	}

	public Resource(){}
	public Resource(
		string title,
		string author,
		ResourceType resourceType,
		ResourceCategory resourceCategory,
		ResourceSubcategory resourceSubcategory
		)
	{
		_resourceType = resourceType;
		_resourceCategory = resourceCategory;
		_resourceSubcategory = resourceSubcategory;
		_title = title;
		_author = author;
		_id = Guid.NewGuid();
	}

	public override string ToString()
	{
		var line1 = $"- Title: {_title}\n";
		var line2 = $"- Author: {_author}\n";
		var line3 = $"- Type: {_resourceType}\n";
		var line4 = $"- Category: {_resourceCategory}\n";
		var line5 = $"- Subcategory: {_resourceSubcategory}\n";
		return line1 + line2 + line3 + line4 + line5;
	}

	// Method to create a deep copy
	public virtual Resource DeepCopy()
	{
		return new Resource(
		 this._title,
		 this._author,
		 this._resourceType,
		 this._resourceCategory,
		 this._resourceSubcategory
		);
	}

	public virtual string ToFile()
	{
		var resourceType = Enum.GetName(typeof(ResourceType), _resourceType);
		var categoryType = Enum.GetName(typeof(ResourceCategory), _resourceCategory);
		var subcategoryType = Enum.GetName(typeof(ResourceSubcategory), _resourceSubcategory);
		return $"{resourceType}:{_id},{_title},{_author},{categoryType},{subcategoryType}";
	}
}