using System;
using System.Security.Authentication;
using System.Web.Mvc;
using System.Web.Security;
using TaskHistory.Api.Users;
using TaskHistory.Orchestrator.Home;
using TaskHistory.ViewModel.Users;

namespace TaskHistory.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
		readonly AuthenticationOrchestrator _orchestrator;
		
		[HttpPost]
		public JsonResult Login(UserLoginViewModel userLoginViewModel)
		{
			if (userLoginViewModel == null)
				throw new ArgumentNullException(nameof(userLoginViewModel));

			IUser user = _orchestrator.ValidateUser(userLoginViewModel);

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

			IUser user = _orchestrator.ValidateAdminUser(userLoginViewModel);

			bool isSuccessful = false;

			if (user != null)
			{
				// TODO Do I need a Session Variable? Probably not. Investigate how to do this using roles
				FormsAuthentication.SetAuthCookie(Guid.NewGuid().ToString(), false);
				Session["IsAdmin"] = true;

				isSuccessful = true;
			}

			return Json(isSuccessful);
		}

		[HttpPost]
		public JsonResult DefaultUserExists()
		{
			if ((bool)Session["IsAdmin"] != true)
				throw new AuthenticationException("Invalid credentials to access Admin Pages");

			return Json(_orchestrator.DefaultUserExists());
		}

		[HttpPost]
		public JsonResult RegisterDefaultUser()
		{
			if ((bool)Session["IsAdmin"] != true)
				throw new AuthenticationException("Invalid credentials to access Admin Pages");

			return Json(_orchestrator.RegisterDefaultUser());
		}

		[HttpPost]
		public JsonResult Logout()
		{
			FormsAuthentication.SignOut();
			return Json(true);
		}

		public AuthenticationController(AuthenticationOrchestrator orchestrator)
		{
			_orchestrator = orchestrator;
		}
    }
}