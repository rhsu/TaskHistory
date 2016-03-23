using System;
using TaskHistoryApi.Users;
using TaskHistoryImpl.MySql;
using MySql.Data.MySqlClient;
using System.Data;

namespace TaskHistoryImpl.Users
{
	public class UserRepo : AbstractMySqlRepo, IUserRepo
	{
		private readonly UserFactory _userFactory;

		public IUser GetUserByUsernameAndPassword (string username, string password)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("User_Validate");
			command.Parameters.Add (new MySqlParameter ("pUsername", username));
			command.Parameters.Add (new MySqlParameter ("pPassword", password));

			MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

			IUser user = null;

			if (reader.Read ()) 
			{
				user = CreateUserFromReader (reader);
			}

			return user;
		}

		private IUser CreateUserFromReader(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			int userId = Convert.ToInt32 (reader ["UserId"]);
			string userName = reader ["Username"].ToString ();
			string firstName = reader ["FirstName"].ToString ();
			string lastName = reader ["LastName"].ToString ();
			string email = reader ["Email"].ToString ();

			var user = _userFactory.CreateUser (userId, userName, firstName, lastName, email);
			return user;
		}

		public UserRepo (MySqlCommandFactory commandFactory, UserFactory userFactory)
			: base (commandFactory)
		{
			_userFactory = userFactory;
		}
	}
}

