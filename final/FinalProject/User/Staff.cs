class Staff : User
{
	private StaffType _staffType;

	public StaffType StaffType
	{
		get { return _staffType; }
		set { _staffType = value; }
	}

	public Staff(
		string username,
		string firstName,
		string lastName,
		string email,
		string password,
		UserType userType,
		StaffType staffType)
		: base(
		username,
		firstName,
		lastName,
		email,
		password,
		userType
		)
	{
		_staffType = staffType;
	}

	public override string ToString()
	{
		var dataFromBase = base.ToString();
		var line1 = $"- Staff type: {_staffType}\n";
		return $"{dataFromBase}{line1}";
	}
}