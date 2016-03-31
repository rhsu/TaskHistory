using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TaskHistory.Orchestrator;
using TaskHistory.ViewModel.Users;

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
		public ActionResult RegisterUser (UserRegisterViewModel userRegisterViewModel)
		{
			_homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);

			return RedirectToAction ("Index");
		}

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

