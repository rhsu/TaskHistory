using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskHistory.WebApp.Controllers
{
    public class HistoryController : Controller
    {
		[HttpGet]
        public ActionResult Index()
        {
            return View ();
        }

		[HttpPost]
		public JsonResult Data()
		{
			return Json(true);
		}
    }
}
