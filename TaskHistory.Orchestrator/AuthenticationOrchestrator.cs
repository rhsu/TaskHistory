using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;

namespace TaskHistory.Orchestrator
{
	public class AuthenticationOrchestrator
	{
		IUserRepo _userRepo;

		public bool OrchestrateLoginUser(UserLoginViewModel userLoginViewModel)
		{
			IUser user = _userRepo.ValidateUsernameAndPassword(userLoginViewModel.Username, userLoginViewModel.Password);
			if (user != null)
			{
				FormsAuthentication.SetAuthCookie(user.Username, false);
				Session["CurrentUser"] = user;
			return true;
		}

		public AuthenticationOrchestrator(IUserRepo userRepo)
		{
			_userRepo = userRepo;
		}
	}
}