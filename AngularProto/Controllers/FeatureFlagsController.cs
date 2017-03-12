using System.Web.Mvc;
using TaskHistory.Orchestrator;
using TaskHistory.ViewModel.FeatureFlags;

namespace AngularProto.Controllers
{
	[Authorize]
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

		[HttpPost]
		public ActionResult Update(FeatureFlagEditViewModel viewModel)
		{
			return Json(_orchestrator.Update(viewModel));
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			return Json(_orchestrator.Delete(id));
		}

		public FeatureFlagsController(FeatureFlagsOrchestrator orchestrator)
		{
			_orchestrator = orchestrator;
		}
	}
}
