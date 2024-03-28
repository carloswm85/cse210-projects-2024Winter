class Staff : User
{
	private StaffType _staffType;

	public StaffType StaffType
	{
		get { return _staffType; }
		set { _staffType = value; }
	}

	public Staff(string firstName, string lastName, StaffType staffType) : base(firstName, lastName)
	{
		_staffType = staffType;
	}

	public override string ToString()
	{
		return $"Staff type: {_staffType}";
	}
}