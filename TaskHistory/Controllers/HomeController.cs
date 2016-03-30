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
	// TODO: https://github.com/rhsu/TaskHistory/issues/39
	public class HomeController: Controller
	{
		[HttpGet]
		public ActionResult Index ()
		{
			return View ();
		}
	}

	public class HomeControllerNew : Controller
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
			if (userRegisterViewModel == null)
				throw new ArgumentNullException ("userRegisterViewModel");

			_homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);

			return RedirectToAction ("Index");
		}

		public HomeControllerNew(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

