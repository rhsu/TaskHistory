using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Controllers
{
    public class TasksController : Controller
    {
		private TasksOrchestrator _taskOrchestrator;

		[HttpGet]
        public ActionResult Index()
        {
			var vmTasks = _taskOrchestrator.OrchestratorGetTasks ();

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
