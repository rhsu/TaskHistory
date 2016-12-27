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
			throw new NotSupportedException("This is no longer supported");
		}

		[HttpPost]
		public ActionResult CreateTask(string content)
		{
			throw new NotSupportedException("This is no longer supported");
		}

		[HttpPost]
		public ActionResult DeleteTask(int taskId)
		{
			throw new NotSupportedException("This is no longer supported");
		}

		public TasksController(TasksOrchestrator taskOrchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_taskOrchestrator = taskOrchestrator;
		}
	}
}