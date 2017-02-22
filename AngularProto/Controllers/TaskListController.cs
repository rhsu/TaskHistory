using System.Web.Mvc;
using TaskHistory.Orchestrator;

namespace AngularProto.Controllers
{
	public class TaskListController : ApplicationController
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
			return Json(_orchestrator.Retrieve(_currentUser));
		}

		[HttpPost]
		public JsonResult Create(string name)
		{
			return Json(_orchestrator.Create(_currentUser, name));
		}

		public TaskListController(TaskListOrchestrator orchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_orchestrator = orchestrator;
		}
    }
}
