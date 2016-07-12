﻿using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;
using TaskHistory.Api.Users;

namespace TaskHistory.Controllers
{
	[Authorize]
    public class TasksController : Controller
    {
		private TasksOrchestrator _taskOrchestrator;

		[HttpGet]
        public ActionResult Index()
        {
			IUser currentUser = (IUser) Session ["CurrentUser"];

			var vmTasks = _taskOrchestrator.OrchestratorGetTasks (currentUser);

			return View (vmTasks);
        }

		[HttpPost]
		public ActionResult CreateTask(string content)
		{
			IUser currentUser = (IUser) Session ["CurrentUser"];

			_taskOrchestrator.OrchestratorCreateTask (currentUser, content);

			return RedirectToAction ("Index");
		}

		public TasksController(TasksOrchestrator taskOrchestrator)
		{
			_taskOrchestrator = taskOrchestrator;
		}
    }
}
