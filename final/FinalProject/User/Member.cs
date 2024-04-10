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

	public Member(
		string username,
		string firstName,
		string lastName,
		string email,
		string password,
		UserType userType,
		MemberType memberType)
		: base(
			username,
			firstName,
			lastName,
			email,
			password,
			userType
			)
	{
		_memberType = memberType;
	}

	public override string ToString()
	{
		var dataFromBase = base.ToString();
		var line1 = $"- Member type: {_memberType}\n";
		return $"{dataFromBase}{line1}";
	}
}