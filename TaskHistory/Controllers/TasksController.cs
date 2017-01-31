using System.Web.Mvc;

namespace TaskHistory.Controllers
{
	// Still leaving this here but DO NOT USE
	[Authorize]
	public class TasksController : Controller
	{
		/*readonly TasksOrchestrator _taskOrchestrator;*/

		// This has been removed
		/*[HttpGet]
		public ActionResult Index()
		{
			var vmTasks = _taskOrchestrator.OrchestratorGetTasks_OLD(_currentUser);
			if (vmTasks == null)
				throw new NullReferenceException("null returned from orchestrator");

			return View(vmTasks);
		}*/

		/*public TasksController(TasksOrchestrator taskOrchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_taskOrchestrator = taskOrchestrator;
		}*/
	}
}