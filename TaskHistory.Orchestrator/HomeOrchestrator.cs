using System;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;
using TaskHistory.ObjectMapper.Users;

namespace TaskHistory.Orchestrator
{
	public class HomeOrchestrator
	{
		private readonly IUserRepo _userRepo;
		private readonly ObjectMapperUsers _userObjectMapper;

		public UserRegistrationStatusViewModel OrchestrateRegisterUser (UserRegistrationParametersViewModel vmUserRegister)
		{
			if (vmUserRegister == null)
				throw new ArgumentNullException ("userParamsViewModel");

			UserRegistrationParameters userParams = _userObjectMapper.Map (vmUserRegister);
			if (userParams == null)
				throw new NullReferenceException ("Null returned from ObjectMapperUser");

			IUser newUser = _userRepo.RegisterUser (userParams);
			// user repo returning null is not an error. Indicates that the user exists already. 
			// Probably should be a better way to indicate this
			//if (newUser == null)
			//	throw new NullReferenceException ("Null returned from UserRepo");

			UserRegistrationStatusViewModel registrationStatus = _userObjectMapper.Map (newUser, vmUserRegister);
			if (registrationStatus == null)
				throw new NullReferenceException ("Null returned from ObjectMapperUser");


			return registrationStatus;
		}

		public HomeOrchestrator (IUserRepo userRepo, ObjectMapperUsers userObjectMapper)
		{
			_userRepo = userRepo;
			_userObjectMapper = userObjectMapper;
		}

	}
}

