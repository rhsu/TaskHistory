﻿using System.ComponentModel.DataAnnotations;

namespace TaskHistory.ViewModel.Users
{
	/// <summary>
	/// View Model for the parameters needed to register a User
	/// </summary>
	public class UserRegistrationParametersViewModel
	{
		[Display(Name = "User Name:")]
		//[Required] 
		// TODO: https://github.com/rhsu/TaskHistory/issues/45 
		// TODO: https://github.com/rhsu/TaskHistory/issues/46
		public string Username { get; set; }

		[Display(Name = "Password:")]
		public string Password { get; set; }

		[Display(Name= "First Name:")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name:")]
		public string LastName { get; set; }

		[Display(Name = "Email:")]
		public string Email { get; set; }

		public UserRegistrationParametersViewModel ()
		{
		}
	}
}