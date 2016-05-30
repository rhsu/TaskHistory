using System;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;
using TaskHistory.ObjectMapper;

namespace TaskHistory.Orchestrator
{
	public class HomeOrchestrator
	{
		private readonly IUserRepo _userRepo;
		private readonly ObjectMapperUser _userObjectMapper;

		public IUser OrchestrateRegisterUser(UserRegistrationParametersViewModel vmUserRegister)
		{
			if (vmUserRegister == null)
				throw new ArgumentNullException ("vmUserRegister");

			IUser newUser = _userRepo.RegisterUser (vmUserRegister.Username, 
				                vmUserRegister.Password, 
				                vmUserRegister.FirstName,
								vmUserRegister.LastName,
				                vmUserRegister.Email);

			return newUser;
		}

		public UserRegistrationStatusViewModel OrchestrateRegisterUser (UserRegistrationParameters userParamsViewModel)
		{
			if (userParamsViewModel == null)
				throw new NullReferenceException ("userParamsViewModel");

			UserRegistrationParameters userParams = _userObjectMapper.Map (userParamsViewModel);



			return null;
		}

		public HomeOrchestrator (IUserRepo userRepo, ObjectMapperUser userObjectMapper)
		{
			_userRepo = userRepo;
			_userObjectMapper = userObjectMapper;
		}

	}
}

