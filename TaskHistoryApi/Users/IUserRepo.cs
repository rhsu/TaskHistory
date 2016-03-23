using System;

namespace TaskHistoryApi.Users
{
	public interface IUserRepo
	{
		IUser GetUserByUsernameAndPassword (string username, string password);
	}
}

