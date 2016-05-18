using System;
using TaskHistory.Api.Users;
using MySql.Data.MySqlClient;

namespace TaskHistoryImpl
{
	public class UserFactory
	{
		public IUser CreateUser (MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			int userId = Convert.ToInt32 (reader ["UserId"]);
			string userName = reader ["Username"].ToString ();
			string firstName = reader ["FirstName"].ToString ();
			string lastName = reader ["LastName"].ToString ();
			string email = reader ["Email"].ToString ();

			return new User (userId, userName, firstName, lastName, email);
		}
	}
}