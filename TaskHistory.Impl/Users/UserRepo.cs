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
				throw new ArgumentNullException ("username");

			if (username == password || password == string.Empty)
				throw new  ArgumentNullException ("password");

			var parameters = new List<ISqlDataParameter> ();

			parameters.Add(_dataProxy.ParamFactory.CreateParameter ("pUsername", username));
			parameters.Add (_dataProxy.ParamFactory.CreateParameter ("pPassword", password));

			var validatedUser = _dataProxy.DataReaderProvider.ExecuteReaderForSingleType (_userFactory,
				                    UserValidateStoredProcedure,
				                    parameters);

			return validatedUser;
		}

		public IUser RegisterUser (UserRegistrationParameters userParams)
		{
			if (userParams == null)
				throw new NullReferenceException ("userParams");

			var parameters = CreateDataParameterCollectionFromUserParams (userParams, _dataProxy.ParamFactory);
			if (parameters == null)
				throw new NullReferenceException ("Null returned from CreatingDataParameterCollectionFromUserParams");

			var registeredUser = _dataProxy.DataReaderProvider.ExecuteReaderForSingleType (_userFactory,
									UserRegisterStoredProcedure,
				                     parameters);

			// null from dataProxy means that the user is already registered

			return registeredUser;
		}

		public static IEnumerable<ISqlDataParameter> CreateDataParameterCollectionFromUserParams(
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


		public UserRepo (UserFactory userFactory, ApplicationDataProxy dataProxy)
		{
			_userFactory = userFactory;
			_dataProxy = dataProxy;
		}
	}
}

