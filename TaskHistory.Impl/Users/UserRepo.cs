using System;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistoryImpl.Users
{
	public class UserRepo : IUserRepo
	{
		private const string UserRegisterStoredProcedure = "Users_Insert";
		private const string UserValidateStoredProcedure = "User_Validate";

		private readonly UserFactory _userFactory;
		private readonly ApplicationDataProxy _dataProxy;

		public IUser ValidateUsernameAndPassword (string username, string password)
		{
			if (username == null || username == string.Empty)
				return ArgumentNullException ("username");

			if (username == password || password == string.Empty)
				return ArgumentNullException ("password");

			return null;
		}

		public IUser RegisterUser (UserRegistrationParameters userParams)
		{
			if (userParams == null)
				throw new NullReferenceException ("userParams");

			var parameters = CreateDataParameterCollectionFromUserParams (userParams);
			if (parameters == null)
				throw new NullReferenceException ("Null returned from CreatingDataParameterCollectionFromUserParams");

			var registeredUser = _dataProxy.DataReaderProvider.ExecuteReaderForSingleType (_userFactory,
									UserRegisterStoredProcedure,
				                     parameters);

			// null from dataProxy means that the user is already registered

			return registeredUser;
		}

		public static IEnumerable<ISqlDataReader> CreateDataParameterCollectionFromUserParams(
			UserRegistrationParameters userParams,
			SqlParameterFactory paramFactory)
		{
			if (userParams == null)
				throw new ArgumentNullException ("userParams");

			if (paramFactory == null)
				throw new ArgumentNullException ("paramFactory");
			
			var returnVal = new List<ISqlDataParameter> ();

			returnVal.Add (paramFactory.CreateParameter("pUsername", userParams.Username));
			returnVal.Add (paramFactory.CreateParameter ("pPassword", userParams.Password));
			returnVal.Add (paramFactory.CreateParameter ("pEmail", userParams.Email));
			returnVal.Add (paramFactory.CreateParameter ("pFirstName", userParams.FirstName));
			returnVal.Add (paramFactory.CreateParameter ("pLastName", userParams.LastName));

			return returnVal;
		}

		/*public IUser ValidateUsernameAndPassword (string username, string password)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand ("User_Validate", connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pUsername", username));
				command.Parameters.Add (new MySqlParameter ("pPassword", password));
				command.Connection.Open ();

				using (var reader = command.ExecuteReader (CommandBehavior.CloseConnection)) 
				{
					IUser user = null;

					if (reader.Read ()) 
					{
						user = _userFactory.CreateUser (reader);
					}

					return user;
				}
			}
		}

		// TODO Refactor using the new DataProvider
		public IUser RegisterUser (UserRegistrationParameters userParams)
		{
			if (userParams == null)
				throw new ArgumentNullException ("userParams");

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand("Users_Insert", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pUsername", userParams.Username));
				command.Parameters.Add (new MySqlParameter ("pPassword", userParams.Password));
				command.Parameters.Add (new MySqlParameter ("pFirstName", userParams.FirstName));
				command.Parameters.Add (new MySqlParameter ("pLastName", userParams.LastName));			
				command.Parameters.Add (new MySqlParameter ("pEmail", userParams.Email));
				command.Connection.Open ();

				using (MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection)) 
				{
					IUser user = null;

					if (reader.Read ()) 
					{
						user = _userFactory.CreateUser (reader);
					}

					return user;
				}
			}
		}*/

		public UserRepo (UserFactory userFactory, ApplicationDataProxy dataProxy)
		{
			_userFactory = userFactory;
			_dataProxy = dataProxy;
		}
	}
}

