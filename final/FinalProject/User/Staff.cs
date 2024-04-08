class Staff : User
{
	private StaffType _staffType;

	public StaffType StaffType
	{
		get { return _staffType; }
		set { _staffType = value; }
	}

	public Staff(string username, string firstName, string lastName, string email, string password, StaffType staffType) : base(username, firstName, lastName, email, password)
	{
		_staffType = staffType;
	}

	public override string ToString()
	{
		var dataFromBase = base.ToString();
		return $"{dataFromBase}- Staff type: {_staffType}";
	}
}