using System;
using TaskHistory.ObjectMapper.Users;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;

namespace TaskHistory.Orchestrator
{
	public class ActivationOrchestrator
	{
		readonly IUserRepo _userRepo;
		readonly ObjectMapperUsers _userObjectMapper;

		public ActivationOrchestrator(IUserRepo userRepo, 
		                              ObjectMapperUsers userObjectMapper)
		{
			_userRepo = userRepo;
			_userObjectMapper = userObjectMapper;
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
	}
}
