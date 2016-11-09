using System.Web.Mvc;
using TaskHistory.Orchestrator.Home;

namespace AngularProto.Controllers
{
	public class HomeController : Controller
	{
		readonly HomeOrchestrator _homeOrchestrator;

		public ActionResult Index ()
		{
			return View ();
		}

		public ActionResult Demo ()
		{
			return View ();
		}

		public HomeController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
	}
}