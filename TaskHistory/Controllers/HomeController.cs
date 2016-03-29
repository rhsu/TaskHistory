using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TaskHistoryOrchestrator;
using TaskHistoryViewModel.ViewModels;

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
			if (userRegisterViewModel == null)
				throw new ArgumentNullException ("userRegisterViewModel");

			_homeOrchestrator.OrchestrateRegisterUser (userRegisterViewModel);

			return RedirectToAction ("Index");
		}

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}

