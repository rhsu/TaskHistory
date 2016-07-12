using System;
using System.Web.Security;
using System.Web.Mvc;
using TaskHistory.Api.Users;
using TaskHistory.ViewModel.Users;
using TaskHistory.Orchestrator.Home;

namespace TaskHistory.Controllers
{
	public class HomeController : Controller
	{
		private HomeOrchestrator _homeOrchestrator;

		[HttpGet]
		public ActionResult Index ()
		{
			return View ();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegisterUser (UserRegistrationParametersViewModel userRegisterViewModel)
		{
			if (userRegisterViewModel == null)
				throw new ArgumentNullException ("userRegisterViewModel");

			UserRegistrationStatusViewModel status = _homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);
			if (status == null)
				throw new NullReferenceException ("Null returned from Home Orchestrator when registering user");

			if (status.ContainsErrors) 
			{
				ViewBag.ErrorStatus = "The user already exists. Please log in in or choose a different user name.";

				return View ("Index");
			} 
			else 
			{
				ViewBag.SuccessStatus = "You are successfully registered";

				return RedirectToAction ("Index");
			}
		}

		[HttpPost]
		public ActionResult LoginUser(UserLoginViewModel userLoginViewModel)
		{
			if (userLoginViewModel == null)
				throw new ArgumentNullException ("userLoginViewModel");

			IUser user = _homeOrchestrator.OrchestrateValidateUser (userLoginViewModel);

			if (user != null) 
			{
				FormsAuthentication.SetAuthCookie (user.Username, false);
				Session ["CurrentUser"] = user;
				return RedirectToAction ("Index", "Tasks");
			}
				
			return RedirectToAction ("Index");
		}

		[HttpGet]
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut ();


			// This is a RedirectToAction rather than a View("Index") because 
			// View keeps the url as Home/Logout whereas this will clear the Url
			return RedirectToAction ("Index");
		}

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

