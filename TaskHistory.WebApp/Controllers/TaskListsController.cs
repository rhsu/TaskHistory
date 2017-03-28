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

		// TODO Might not need this
		[HttpPost]
		public JsonResult Retrieve()
		{
			//return Json(_orchestrator.Retrieve(_currentUser));
			return null;
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
