using System;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;

namespace TaskHistory.Orchestrator.Home
{
	public class AuthenticationOrchestrator
	{
		readonly IUserRepo _userRepo;
		readonly IAdminUserProvider _adminUserProvider;

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