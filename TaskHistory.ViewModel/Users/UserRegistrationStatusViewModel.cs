using System;

namespace TaskHistory.ViewModel.Users
{
	/// <summary>
	/// View Model Representing the status to display after a user requests a registration
	/// </summary>UserRegistrationParametersViewModel
	public class UserRegistrationStatusViewModel
	{
		public bool ContainsErrors { get; }
		public string FirstName { get; }
		public string Username { get; }
		public string Email { get; }

		public UserRegistrationStatusViewModel (bool containsErrors, 
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

