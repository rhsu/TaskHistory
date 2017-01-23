using System.Web.Mvc;
using TaskHistory.Orchestrator;

namespace AngularProto.Controllers
{
	public class FeatureFlagsController : Controller
	{
		FeatureFlagsOrchestrator _orchestrator;

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
			return Json(_orchestrator.GetFlags());
		}

		public FeatureFlagsController(FeatureFlagsOrchestrator orchestrator)
		{
			_orchestrator = orchestrator;
		}
	}
}
