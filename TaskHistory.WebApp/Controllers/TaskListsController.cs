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
		// TODO temporary patch
		public JsonResult Read()
		{
			return Json(_orchestrator.ReadAll(_currentUser));
		}

		/*[HttpPost]
		public JsonResult Read(int listId)
		{
			return Json(_orchestrator.Read(_currentUser, listId));
		}*/

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
