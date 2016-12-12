using System;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;
using TaskHistory.ObjectMapper.Users;

namespace TaskHistory.Orchestrator.Home
{
	public class AuthenticationOrchestrator
	{
		readonly IUserRepo _userRepo;
		readonly ObjectMapperUsers _userObjectMapper;

		public UserRegistrationStatusViewModel OrchestrateRegisterUser(UserRegistrationParametersViewModel vmUserRegister)
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
		}

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

		public AuthenticationOrchestrator(IUserRepo userRepo, ObjectMapperUsers userObjectMapper)
		{
			_userRepo = userRepo;
			_userObjectMapper = userObjectMapper;
		}
	}
}