using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TaskHistory.Orchestrator;
using TaskHistory.ViewModel.Users;
using TaskHistory.Api.Users;

namespace TaskHistory.Controllers
{
	public class HomeController : Controller
	{
		private HomeOrchestrator _homeOrchestrator;

		[HttpGet]
		public ActionResult Index (UserRegistrationStatusViewModel confirmationViewModel)
		{
			ViewBag.UserRegistered = confirmationViewModel;

			return View ();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegisterUser (UserRegistrationParametersViewModel userRegisterViewModel)
		{
			UserRegistrationStatusViewModel status = _homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);

			/*if (status.ContainsErrors) 
			{
				return View ("Index", status);
			} 
			else 
			{
			}*/

			/* if null (return View ("Index", with some message"Didn't work"
			 * else
			 * return RedirectToAction ("Successfully Registered"
			 * /

			/*IUser user = null;

			if (user == null) 
			{
				return View ("Index");
			} 
			else 
			{
				return RedirectToAction ("Something");

			}*/

			//return RedirectToAction ("Index", new );
		}

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

