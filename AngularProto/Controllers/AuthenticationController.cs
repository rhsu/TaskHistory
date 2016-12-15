using System.Web.Mvc;
using System.Web.Security;
using TaskHistory.Api.Users;
using TaskHistory.Orchestrator.Home;
using TaskHistory.ViewModel.Users;

namespace AngularProto.Controllers
{
    public class AuthenticationController : Controller
    {
		readonly AuthenticationOrchestrator _authenticationOrchestrator;
		
		[HttpPost]
		public JsonResult Login(UserLoginViewModel userLoginViewModel)
		{
			IUser user = _authenticationOrchestrator.OrchestrateValidateUser(userLoginViewModel);
			bool isSuccessful = false;

			if (user != null)
			{
				FormsAuthentication.SetAuthCookie(user.Username, false);
				Session["CurrentUser"] = user;

				isSuccessful = true;
			}
			//TODO should user be authenticated and session cleared if Login failed?

			return Json(isSuccessful);
		}

		public AuthenticationController(AuthenticationOrchestrator homeOrchestrator)
		{
			_authenticationOrchestrator = homeOrchestrator;
		}
    }
}