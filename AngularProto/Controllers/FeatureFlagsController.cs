using System.Security.Authentication;
using System.Web.Mvc;
using TaskHistory.Orchestrator;
using TaskHistory.ViewModel.FeatureFlags;

namespace TaskHistory.WebApp.Controllers
{
	[Authorize]
	public class FeatureFlagsController : Controller
	{
		FeatureFlagsOrchestrator _orchestrator;

		[HttpGet]
		public ActionResult Index()
		{
			if ((bool)Session["IsAdmin"] != true)
				throw new AuthenticationException("Invalid credentials to access Admin Pages");

			return View();
		}

		[HttpPost]
		public ActionResult Create(FeatureFlagCreateViewModel viewModel)
		{
			if ((bool)Session["IsAdmin"] != true)
				throw new AuthenticationException("Invalid credentials to access Admin Pages");

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
			if ((bool)Session["IsAdmin"] != true)
				throw new AuthenticationException("Invalid credentials to access Admin Pages");

			return Json(_orchestrator.Update(viewModel));
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			if ((bool)Session["IsAdmin"] != true)
				throw new AuthenticationException("Invalid credentials to access Admin Pages");

			return Json(_orchestrator.Delete(id));
		}

		public FeatureFlagsController(FeatureFlagsOrchestrator orchestrator)
		{
			_orchestrator = orchestrator;
		}
	}
}
