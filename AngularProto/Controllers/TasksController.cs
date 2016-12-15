using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;

namespace AngularProto.Controllers
{
	//[Authorize]
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
			return Json(_taskOrchestrator.OrchestratorGetTasks_OLD(_currentUser));
		}

		[HttpPost]
		public JsonResult CreateTask(string content)
		{
			return Json(_taskOrchestrator.OrchestratorCreateTask_OLD(_currentUser, content));
		}

		[HttpPost]
		public ActionResult DeleteTask(int taskId)
		{
			_taskOrchestrator.OrchestratorDeleteTask(_currentUser, taskId);

			return RedirectToAction("Index");
		}

		public TasksController(TasksOrchestrator taskOrchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_taskOrchestrator = taskOrchestrator;
		}
	}
}