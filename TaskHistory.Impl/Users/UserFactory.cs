using System;
using TaskHistory.Api.Users;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Users
{
	public class UserFactory : IFromDataReaderFactory<IUser>
	{
		public IUser Build(int userId, 
		                   string userName, 
		                   string firstName, 
		                   string lastName, 
		                   string email)
		{
			return new User(userId, userName, firstName, lastName, email);
		}

		public IUser Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));

			int userId = reader.GetInt("userId");
			string userName = reader.GetString("userName");
			string firstName = reader.GetString("firstName");
			string lastName = reader.GetString("lastName");
			string email = reader.GetString("email");

			return new User(userId, userName, firstName, lastName, email);
		}
	}
}