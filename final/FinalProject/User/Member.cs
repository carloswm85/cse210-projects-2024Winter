/// <summary>
/// 
/// </summary>
class Member : User
{
	private MemberType _memberType;

	public MemberType MemberType
	{
		get { return _memberType; }
		set { _memberType = value; }
	}

	private DateTime _registrationDate;
	public DateTime RegistrationDate {
		get { return _registrationDate; }
		set { _registrationDate = value; }
	}

	private List<Guid> _borrowedResources;
	public List<Guid> BorrowedResources {
		get { return _borrowedResources; }
		set { _borrowedResources = value; }
	}

	private double _dueFine;
	public double DueFine {
		get { return _dueFine; }
		set { _dueFine = value; }
	}

	public Member(string username, string firstName, string lastName, string email, MemberType MemberType) : base(username, firstName, lastName, email)
	{
		_memberType = MemberType;
	}

	public override string ToString()
	{
		return $"Member type: {_memberType} - Registration date: {_registrationDate}";
	}
}