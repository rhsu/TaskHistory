using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;
using TaskHistory.ViewModel.Tasks;

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
		public JsonResult CreateTask(string content, int listId)
		{
			return Json(_taskOrchestrator.OrchestrateCreateTask(_currentUser, listId, content));
		}

		[HttpPost]
		public JsonResult EditTask(TaskEditViewModel taskEditViewModel, int taskId)
		{
			return Json(_taskOrchestrator.OrchestrateEditTask(_currentUser,
			                                                 taskId,
			                                                  taskEditViewModel));
		}

		public TasksController(TasksOrchestrator taskOrchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_taskOrchestrator = taskOrchestrator;
		}
	}
}