using System.Web.Mvc;

namespace AngularProto.Controllers
{
	public class RoutesDemoController : Controller
	{
		public ActionResult One()
		{
			return View();
		}

		public ActionResult Two(int donuts = 1)
		{
			ViewBag.Donuts = donuts;
			return View();
		}

		public ActionResult Hello()
		{
			return Json(5);
		}

		public ActionResult PostData(TestModel model)
		{
			return Json(model);
		}

		[Authorize]
		public ActionResult Three()
		{
			return View();
		}
	}
}
