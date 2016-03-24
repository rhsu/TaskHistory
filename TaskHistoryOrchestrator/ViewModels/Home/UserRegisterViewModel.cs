using System;
using TaskHistoryApi.Users;

namespace TaskHistoryOrchestrator.ViewModels
{
	public class UserRegisterViewModel
	{
		public int? UserId { get; }
		public string Username { get; }
		public string Password { get; }
		public string Email { get; }

		public UserRegisterViewModel ()
		{
		}

		public IUser ConverToUserObject()
		{
			return null;
		}
	}
}