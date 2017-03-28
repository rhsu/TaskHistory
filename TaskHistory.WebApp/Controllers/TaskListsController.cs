using System.Web.Mvc;
using TaskHistory.Orchestrator;

namespace TaskHistory.WebApp.Controllers
{
	public class TaskListsController : ApplicationController
    {
		TaskListOrchestrator _orchestrator;

		[HttpGet]
        public ActionResult Index()
        {
            return View ();
        }

		[HttpPost]
		public JsonResult Retrieve()
		{
			return Json(_orchestrator.Read(_currentUser));
		}

		[HttpPost]
		public JsonResult Create(string name)
		{
			return Json(_orchestrator.Create(_currentUser, name));
		}

		public TaskListsController(TaskListOrchestrator orchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_orchestrator = orchestrator;
		}
    }
}
