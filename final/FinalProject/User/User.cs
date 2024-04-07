class User
{
	private string _username;
	public string Username {
		get { return _username; }
		set { _username = value; }
	}

	private string _firstName;
	public string FirstName {
		get { return _firstName; }
		set { _firstName = value; }
	}
	
	private string _lastName;
	public string LastName {
		get { return _lastName; }
		set { _lastName = value; }
	}

	private string _email;
	public string Email {
		get { return _email; }
		set { _email = value; }
	}

	public User(string username, string firstName, string lastName, string email)
	{
		_username = username;
		_firstName = firstName;
		_lastName = lastName;
		_email = email;
	}

	public override string ToString()
	{
		var line1 = $"\nFull name: {_firstName} {_lastName}\n";
		var line2 = $"Email: {_email}\n";
		return line1 + line2;
	}
}