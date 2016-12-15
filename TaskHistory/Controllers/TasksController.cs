using System;
using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;

namespace TaskHistory.Controllers
{
	[Authorize]
	public class TasksController : ApplicationController
	{
		readonly TasksOrchestrator _taskOrchestrator;

		[HttpGet]
		public ActionResult Index()
		{
			var vmTasks = _taskOrchestrator.OrchestratorGetTasks_OLD(_currentUser);
			if (vmTasks == null)
				throw new NullReferenceException("null returned from orchestrator");

			return View(vmTasks);
		}

		[HttpPost]
		public ActionResult CreateTask(string content)
		{
			_taskOrchestrator.OrchestratorCreateTask_OLD(_currentUser, content);

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