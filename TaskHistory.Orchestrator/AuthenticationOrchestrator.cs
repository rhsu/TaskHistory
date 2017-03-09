using System;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;
using TaskHistory.ObjectMapper.Users;

namespace TaskHistory.Orchestrator.Home
{
	public class AuthenticationOrchestrator
	{
		readonly IUserRepo _userRepo;
		readonly IAdminUserProvider _adminUserProvider;

		// TODO This has been moved. Do not call this anymore
		/*public UserRegistrationStatusViewModel OrchestrateRegisterUser(UserRegistrationParametersViewModel vmUserRegister)
		{
			if (vmUserRegister == null)
				throw new ArgumentNullException(nameof(vmUserRegister));

			UserRegistrationParameters userParams = _userObjectMapper.Map(vmUserRegister);
			if (userParams == null)
				throw new NullReferenceException("Null returned from ObjectMapperUser");

			IUser newUser = _userRepo.RegisterUser(userParams);
			// [TODO] https://github.com/rhsu/TaskHistory/issues/124
			// user repo returning null is not an exception. Indicates that the user exists already. 
			// Probably should be a better way to indicate this

			UserRegistrationStatusViewModel registrationStatus = _userObjectMapper.Map(newUser, vmUserRegister);
			if (registrationStatus == null)
				throw new NullReferenceException("Null returned from ObjectMapperUser");


			return registrationStatus;
		}*/

		public IUser OrchestrateValidateUser(UserLoginViewModel userLoginViewModel)
		{
			if (userLoginViewModel == null)
				throw new ArgumentNullException(nameof(userLoginViewModel));

			IUser user = _userRepo.ValidateUsernameAndPassword(userLoginViewModel.Username, userLoginViewModel.Password);
			// [TODO] https://github.com/rhsu/TaskHistory/issues/124
			// user repo returning null is not an exception. Indicates that the username/password combination is not correct.
			// Probably should be a better way to indicate this

			return user;
		}

		public IUser OrchestratorValidateAdminUser(UserLoginViewModel userLoginViewModel)
		{
			if (userLoginViewModel == null)
				throw new ArgumentNullException(nameof(userLoginViewModel));

			string username = userLoginViewModel.Username;
			string password = userLoginViewModel.Password;

			IUser user = _adminUserProvider.AuthenticateAdminUser(username, password);

			return user;
		}

		public AuthenticationOrchestrator(IUserRepo userRepo, 
		                                  IAdminUserProvider adminUserProvider)
		{
			_adminUserProvider = adminUserProvider;
			_userRepo = userRepo;
		}
	}
}