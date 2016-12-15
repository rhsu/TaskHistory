using System;
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

		[HttpGet]
		public JsonResult GetTasks()
		{
			return Json(_taskOrchestrator.OrchestratorGetTasks(_currentUser));
		}

		[HttpPost]
		public ActionResult CreateTask(string content)
		{
			_taskOrchestrator.OrchestratorCreateTask(_currentUser, content);

			return RedirectToAction("Index");
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