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
		public ActionResult Index ()
		{
			return View ();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RegisterUser (UserRegistrationParametersViewModel userRegisterViewModel)
		{
			UserRegistrationStatusViewModel status = _homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);

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

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

