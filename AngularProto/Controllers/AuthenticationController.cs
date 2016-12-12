using System.Web.Mvc;
using System.Web.Security;
using TaskHistory.Api.Users;
using TaskHistory.Orchestrator.Home;
using TaskHistory.ViewModel.Users;

namespace AngularProto.Controllers
{
    public class AuthenticationController : Controller
    {
		//TODO refator this to Authentication Orchestrator
		readonly AuthenticationOrchestrator _homeOrchestrator;
		
		[HttpPost]
		public JsonResult Login(UserLoginViewModel userLoginViewModel)
		{
			IUser user = _homeOrchestrator.OrchestrateValidateUser(userLoginViewModel);
			bool isSuccessful = false;

			if (user != null)
			{
				FormsAuthentication.SetAuthCookie(user.Username, false);
				Session["CurrentUser"] = user;

				isSuccessful = true;
			}

			return Json(isSuccessful);
		}

		public AuthenticationController(AuthenticationOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
    }
}