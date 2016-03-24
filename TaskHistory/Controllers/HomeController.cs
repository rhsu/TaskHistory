using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TaskHistoryOrchestrator.ViewModels;

namespace TaskHistory.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index ()
		{
			return View ();
		}

		[HttpPost]
		public ActionResult RegisterUser(UserRegisterViewModel userRegister)
		{


			return RedirectToAction ("Index");
		}
	}
}

