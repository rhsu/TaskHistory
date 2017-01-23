using System.Web.Mvc;

namespace AngularProto.Controllers
{
	public class FeatureFlagsController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create()
		{
			return Json(true);
		}

		[HttpPost]
		public ActionResult Get()
		{
			return Json(true);
		}
	}
}
