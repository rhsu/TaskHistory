using System;
using TaskHistory.Api.Users;
using TaskHistory.ObjectMapper.Users;
using TaskHistory.ViewModel.Users;

namespace TaskHistory.Orchestrator.Home
{
	public class AuthenticationOrchestrator
	{
		readonly IUserRepo _userRepo;
		readonly ObjectMapperUsers _userObjectMapper;
		readonly IAdminUserProvider _adminUserProvider;
		readonly IDefaultUserProvider _defaultUserProvider;

		public IUser ValidateUser(UserLoginViewModel userLoginViewModel)
		{
			if (userLoginViewModel == null)
				throw new ArgumentNullException(nameof(userLoginViewModel));

			IUser user = _userRepo.ValidateUsernameAndPassword(userLoginViewModel.Username, userLoginViewModel.Password);
			// [TODO] https://github.com/rhsu/TaskHistory/issues/124
			// user repo returning null is not an exception. Indicates that the username/password combination is not correct.
			// Probably should be a better way to indicate this

			return user;
		}

		public IUser ValidateAdminUser(UserLoginViewModel userLoginViewModel)
		{
			if (userLoginViewModel == null)
				throw new ArgumentNullException(nameof(userLoginViewModel));

			string username = userLoginViewModel.Username;
			string password = userLoginViewModel.Password;

			IUser user = _adminUserProvider.AuthenticateAdminUser(username, password);

			return user;
		}

		public bool DefaultUserExists()
		{
			var exists = _defaultUserProvider.DefaultUserExists();
			return exists;
		}

		public IUser RegisterDefaultUser()
		{
			var user = _defaultUserProvider.RegisterDefaultUser();
			if (user == null)
				throw new NullReferenceException("null user returned from admin user provider when registering default user");

			// TODO should havea  UserViewModel instead of returning the entire IUser object

			return user;
		}

		public bool RegisterUser(UserRegistrationParametersViewModel vmUserRegister)
		{
			if (vmUserRegister == null)
				throw new ArgumentNullException(nameof(vmUserRegister));

			UserRegistrationParameters userParams = _userObjectMapper.Map(vmUserRegister);
			if (userParams == null)
				throw new NullReferenceException("Null returned from ObjectMapperUser");

			IUser newUser = _userRepo.RegisterUser(userParams);

			return (newUser != null);
		}

		public AuthenticationOrchestrator(IUserRepo userRepo,
										  IAdminUserProvider adminUserProvider,
		                                  IDefaultUserProvider defaultUserProvider,
		                                  ObjectMapperUsers userObjectMapper)
		{
			_adminUserProvider = adminUserProvider;
			_userRepo = userRepo;
			_defaultUserProvider = defaultUserProvider;
			_userObjectMapper = userObjectMapper;
		}
	}
}