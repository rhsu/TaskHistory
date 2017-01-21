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
	}
}
