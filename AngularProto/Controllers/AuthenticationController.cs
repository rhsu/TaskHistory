using System;
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
			if (userLoginViewModel == null)
				throw new ArgumentNullException(nameof(userLoginViewModel));

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

		[HttpPost]
		public JsonResult AdminLogin(UserLoginViewModel userLoginViewModel)
		{
			if (userLoginViewModel == null)
				throw new ArgumentNullException(nameof(userLoginViewModel));

			IUser user = _authenticationOrchestrator.OrchestrateValidateUser(userLoginViewModel);

			return Json(false);
		}

		[HttpPost]
		public JsonResult Logout()
		{
			FormsAuthentication.SignOut();
			return Json(true);
		}

		public AuthenticationController(AuthenticationOrchestrator homeOrchestrator)
		{
			_authenticationOrchestrator = homeOrchestrator;
		}
    }
}