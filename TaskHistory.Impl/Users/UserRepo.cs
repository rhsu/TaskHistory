using System;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.Users
{
	public class UserRepo : IUserRepo
	{
		private const string UserRegisterStoredProcedure = "Users_Insert";
		private const string UserValidateStoredProcedure = "User_Validate";

		private readonly UserFactory _userFactory;
		private readonly IApplicationDataProxy _dataProxy;

		public IUser ValidateUsernameAndPassword(string username, string password)
		{
			if (username == null || username == string.Empty)
				throw new ArgumentNullException("username");

			if (username == null || password == string.Empty)
				throw new ArgumentNullException("password");

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.ParamFactory.CreateParameter("pUsername", username));
			parameters.Add(_dataProxy.ParamFactory.CreateParameter("pPassword", password));

			var validatedUser = _dataProxy.DataReaderProvider.ExecuteReaderForSingleType(_userFactory,
									UserValidateStoredProcedure,
									parameters);
			// [TODO] https://github.com/rhsu/TaskHistory/issues/124
			//null means that the user is not valid
			return validatedUser;
		}

		public IUser RegisterUser(UserRegistrationParameters userParams)
		{
			if (userParams == null)
				throw new NullReferenceException("userParams");

			var parameters = CreateDataParameterCollectionFromUserParams(userParams, _dataProxy.ParamFactory);
			if (parameters == null)
				throw new NullReferenceException("Null returned from CreatingDataParameterCollectionFromUserParams");

			var registeredUser = _dataProxy.DataReaderProvider.ExecuteReaderForSingleType(_userFactory,
									UserRegisterStoredProcedure,
									 parameters);
			// [TODO] https://github.com/rhsu/TaskHistory/issues/124
			// null from dataProxy means that the user is already registered
			return registeredUser;
		}

		public IEnumerable<IUser> ReadAllUsers(int limit)
		{
			var returnVal = new List<IUser>();

			for (var i = 0; i < 3; i++)
			{
				string userName = string.Format("UserName{0}", i);
				string firstName = string.Format("FirstName{0}", i);
				string lastName = string.Format("LastName{0}", i);

				returnVal.Add(new User(i, userName, firstName, lastName, "@yahoo.com"));
			}

			return returnVal;
		}

		public static IEnumerable<ISqlDataParameter> CreateDataParameterCollectionFromUserParams(
			UserRegistrationParameters userParams,
			ISqlParameterFactory paramFactory)
		{
			if (userParams == null)
				throw new ArgumentNullException("userParams");

			if (paramFactory == null)
				throw new ArgumentNullException("paramFactory");

			var returnVal = new List<ISqlDataParameter>();

			returnVal.Add(paramFactory.CreateParameter("pUsername", userParams.Username));
			returnVal.Add(paramFactory.CreateParameter("pPassword", userParams.Password));
			returnVal.Add(paramFactory.CreateParameter("pEmail", userParams.Email));
			returnVal.Add(paramFactory.CreateParameter("pFirstName", userParams.FirstName));
			returnVal.Add(paramFactory.CreateParameter("pLastName", userParams.LastName));

			return returnVal;
		}

		public UserRepo (UserFactory userFactory, IApplicationDataProxy dataProxy)
		{
			_userFactory = userFactory;
			_dataProxy = dataProxy;
		}
	}
}

