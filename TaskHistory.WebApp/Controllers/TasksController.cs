using System.Web.Mvc;
using TaskHistory.Orchestrator.Tasks;
using TaskHistory.ViewModel.Tasks;

namespace TaskHistory.WebApp.Controllers
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
		public JsonResult Retrieve()
		{
			return Json(_taskOrchestrator.Read(_currentUser));
		}

		[HttpPost]
		public JsonResult Create(string content)
		{
			return Json(_taskOrchestrator.Create(_currentUser, content));
		}

		[HttpPost]
		public JsonResult CreateTaskOnList(int listId, string taskContent)
		{
			return Json(_taskOrchestrator.CreateOnList(_currentUser,
													   listId,
			                                           taskContent));
		}

		[HttpPost]
		public JsonResult Edit(TaskEditViewModel viewModel, int taskId)
		{
			return Json(_taskOrchestrator.Update(_currentUser,
			                                   taskId,
			                                   viewModel));
		}

		public TasksController(TasksOrchestrator taskOrchestrator, ApplicationContext appContext)
			: base(appContext)
		{
			_taskOrchestrator = taskOrchestrator;
		}
	}
}