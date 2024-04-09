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

	private string _password = string.Empty;
	public string Password {
		get { return _password; }
		set { _password = value; }
	}

	protected DateTime _registrationDate;
	public DateTime RegistrationDate
	{
		get { return _registrationDate; }
		set { _registrationDate = value; }
	}

	private bool _isLoggedIn;
	public bool IsLoggedIn {
		get { return _isLoggedIn; }
		set { _isLoggedIn = value; }
	}

	public User(string username, string firstName, string lastName, string email, string password)
	{
		_username = username;
		_firstName = firstName;
		_lastName = lastName;
		_email = email;
		_password = password;
		_registrationDate = DateTime.Now;
		_isLoggedIn = false;
	}

	public override string ToString()
	{
		var formattedDate = _registrationDate.ToString("MM/dd/yyyy");
		var line1 = $"- Full name: {_firstName} {_lastName}\n";
		var line2 = $"- Email: {_email}\n";
		var line3 = $"- Registration date: {formattedDate}\n";
		var passwordSet = _password == "" ? "NO" : "YES";
		var line4 = $"- Password is set: {passwordSet}\n";
		return line1 + line2 + line3 + line4;
	}
}