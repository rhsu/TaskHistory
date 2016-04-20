using System;

namespace TaskHistory.ViewModel.Users
{
	public class UserSuccessfulRegisteredViewModel
	{
		public bool ContainsErrors { get; }
		public string FirstName { get; }
		public string Username { get; }
		public string Email { get; }

		public UserSuccessfulRegisteredViewModel()
		{
		}

		public UserSuccessfulRegisteredViewModel (bool containsErrors, 
			string firstName, 
			string userName, 
			string email)
		{
			this.ContainsErrors = containsErrors;

			if (!containsErrors) 
			{
				this.FirstName = firstName;
				this.Username = userName;
				this.Email = email;
			}
		}
	}
}

