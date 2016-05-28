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
			IUser user = _homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);

			if (user == null) 
			{
				return View ("Index");//RedirectToAction ("Index");
			} 
			else 
			{
				// return RedirectToAction ("Something");
				return View ("Index");
			}

			return RedirectToAction ("Index");
		}

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

