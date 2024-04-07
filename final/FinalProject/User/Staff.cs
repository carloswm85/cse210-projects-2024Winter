class Staff : User
{
	private StaffType _staffType;

	public StaffType StaffType
	{
		get { return _staffType; }
		set { _staffType = value; }
	}

	public Staff(string username, string firstName, string lastName, string email, StaffType staffType) : base(username, firstName, lastName, email)
	{
		_staffType = staffType;
	}

	public override string ToString()
	{
		return $"Staff type: {_staffType}";
	}
}