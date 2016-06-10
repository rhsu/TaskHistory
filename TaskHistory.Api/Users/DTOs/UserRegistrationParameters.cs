using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;

namespace TaskHistory.Api.Users
{
	public class UserRegistrationParameters
	{
		public string Username { get; }
		public string Password { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string Email { get; }

		public UserRegistrationParameters (string username, 
			string password, 
			string firstName, 
			string lastName, 
			string email)
		{
			Username = username;
			Password = password;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}
	}
}

