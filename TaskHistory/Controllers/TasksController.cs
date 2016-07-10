using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;
using TaskHistory.Api.Tasks;
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
			_taskOrchestrator.OrchestratorCreateTask (content);

			return RedirectToAction ("Index");
		}

		public TasksController(TasksOrchestrator taskOrchestrator)
		{
			_taskOrchestrator = taskOrchestrator;
		}
    }
}
