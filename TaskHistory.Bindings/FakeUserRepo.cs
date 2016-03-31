using System;
using TaskHistory.Api.Users;

namespace TaskHistory.Bindings
{
	public class FakeUser : IUser
	{
		public int UserId { get; }
		public string Username { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string FullName { get; }
		public string Email { get; }

		public FakeUser()
		{
			this.UserId = 1;
			this.Username = "Steve";
			this.FirstName = "WTF";
			this.LastName = "WUT";
			this.FullName = "WHATEVER";
			this.Email = "123@gmail.com";
		}
	}

	public class FakeUserRepo : IUserRepo
	{
		public IUser ValidateUsernameAndPassword (string username, string password)
		{
			return new FakeUser();
		}

		public IUser RegisterUser (string username, string password, string firstName, string lastName, string email)
		{
			return new FakeUser ();
		}

		public FakeUserRepo ()
		{
		}
	}
}

