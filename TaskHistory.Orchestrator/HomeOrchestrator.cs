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
				throw new NullReferenceException ("userParamsViewModel");

			UserRegistrationParameters userParams = _userObjectMapper.Map (vmUserRegister);

			IUser newUser = _userRepo.RegisterUser (userParams);

			UserRegistrationStatusViewModel registrationStatus = _userObjectMapper.Map (newUser, vmUserRegister);

			//return newUser;

			throw new NotImplementedException ("This is not implemented yet");
		}

		public HomeOrchestrator (IUserRepo userRepo, ObjectMapperUsers userObjectMapper)
		{
			_userRepo = userRepo;
			_userObjectMapper = userObjectMapper;
		}

	}
}

