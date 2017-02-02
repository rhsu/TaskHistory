using System.Web.Mvc;
using TaskHistory.Orchestrator;
using TaskHistory.ViewModel.FeatureFlags;

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
		public ActionResult Create(FeatureFlagCreateViewModel viewModel)
		{
			return Json(_orchestrator.Create(viewModel));
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
