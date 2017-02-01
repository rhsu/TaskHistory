using System.Web.Mvc;

namespace TaskHistory.WebApp.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}
	}
}