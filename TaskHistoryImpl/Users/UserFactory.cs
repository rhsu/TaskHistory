using System;
using TaskHistory.Api.Users;

namespace TaskHistoryImpl
{
	public class UserFactory
	{
		public IUser CreateUser (int id, string userName, string firstName, string lastName, string email)
		{
			return new User (id, userName, firstName, lastName, email);
		}
	}
}