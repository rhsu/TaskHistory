using System;
using TaskHistoryApi.Users;

namespace TaskHistoryImpl
{
	public class User : IUser
	{
		public int UserId { get; }
		public string Username { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string FullName { get { return this.FirstName + " " + this.LastName; } }
		public string Email { get; }

		public User (int id, string userName, string firstName, string lastName, string email)
		{
			UserId = id;
			Username = userName;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}
	}
}

