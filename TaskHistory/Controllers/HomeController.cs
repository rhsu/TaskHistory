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
		public ActionResult Index (UserSuccessfulRegisteredViewModel confirmationViewModel)
		{
			ViewBag.UserRegistered = confirmationViewModel;

			return View ();
		}

		[HttpPost]
		public ActionResult RegisterUser (UserRegisterViewModel userRegisterViewModel)
		{
			IUser user = _homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);

			if (user == null) 
			{
				return RedirectToAction ("Index");
			} 
			else 
			{
				return RedirectToAction ("Something");
			}

			return RedirectToAction ("Index");
		}

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

