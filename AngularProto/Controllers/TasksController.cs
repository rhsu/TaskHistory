using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;

namespace AngularProto.Controllers
{
	[Authorize]
	public class TasksController : ApplicationController
	{
		readonly TasksOrchestrator _taskOrchestrator;

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public JsonResult GetTasks()
		{
			return Json(_taskOrchestrator.OrchestrateGetTasks(_currentUser));
		}

		[HttpPost]
		public JsonResult CreateTask(string content)
		{
			return Json(_taskOrchestrator.OrchestrateCreateTask(_currentUser, content));
		}

		[HttpPost]
		public JsonResult DeleteTask(int taskId)
		{
			return Json(_taskOrchestrator.OrchestratorDeleteTask(_currentUser, taskId));
		}

		public TasksController(TasksOrchestrator taskOrchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_taskOrchestrator = taskOrchestrator;
		}
	}
}