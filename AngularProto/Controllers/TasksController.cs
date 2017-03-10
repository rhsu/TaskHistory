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
			// TODO figure out role
			// TODO figure out before filter ("might be easier to do first")
			/*if (Session["IsAdmin"] != true)
				throw new Exception("Can't access");*/
			return View();
		}

		[HttpPost]
		public JsonResult Retrieve()
		{
			return Json(_taskOrchestrator.Retrieve(_currentUser));
		}

		[HttpPost]
		public JsonResult Create(string content)
		{
			return Json(_taskOrchestrator.Create(_currentUser, content));
		}

		[HttpPost]
		public JsonResult Edit(TaskEditViewModel viewModel, int taskId)
		{
			return Json(_taskOrchestrator.Edit(_currentUser,
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