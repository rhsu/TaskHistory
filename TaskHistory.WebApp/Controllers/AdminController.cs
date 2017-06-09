using System.Web.Mvc;

namespace TaskHistory.WebApp.Controllers
{
	public class AdminController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
	}
}
