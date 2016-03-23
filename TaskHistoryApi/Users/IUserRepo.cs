using System;

namespace TaskHistoryApi.Users
{
	public interface IUserRepo
	{
		IUser GetUserByUsernameAndPassword (string username, string password);

		IUser RegisterUser (string username, string password, string firstName, string lastName, string email);
	}
}

