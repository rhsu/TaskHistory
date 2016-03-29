using System;
using TaskHistoryApi.Users;
using TaskHistoryViewModel.ViewModels;

namespace TaskHistoryOrchestrator
{
	public class UserOrchestrator
	{
		private IUserRepo _userRepo;

		public IUser OrchestrateRegisterUser(UserRegisterViewModel vmUserRegister)
		{
			if (vmUserRegister == null)
				throw new ArgumentNullException ("vmUserRegister");

			IUser newUser = _userRepo.RegisterUser (vmUserRegister.Username, 
				                vmUserRegister.Password, 
				                vmUserRegister.FirstName,
								vmUserRegister.LastName,
				                vmUserRegister.Email);

			if (newUser == null)
				throw new NullReferenceException ("Null IUser object returned from user repo when registering a user");

			return newUser;
		}

		public UserOrchestrator (IUserRepo userRepo)
		{
			_userRepo = userRepo;
		}
	}
}

