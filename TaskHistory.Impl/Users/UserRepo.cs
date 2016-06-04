﻿using System;
using TaskHistory.Api.Users;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace TaskHistoryImpl.Users
{
	public class UserRepo : IUserRepo
	{
		private readonly UserFactory _userFactory;

		public IUser ValidateUsernameAndPassword (string username, string password)
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
		}

		public UserRepo (UserFactory userFactory)
		{
			_userFactory = userFactory;
		}
	}
}

