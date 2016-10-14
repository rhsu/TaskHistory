using System.Web.Mvc;
using TaskHistory.Api.Users;
using TaskHistory.Orchestrator.Tasks;

namespace TaskHistory.Controllers
{
	[Authorize]
    public class TasksController : Controller
    {
		TasksOrchestrator _taskOrchestrator;
		IUser _currentUser;

		[HttpGet]
        public ActionResult Index()
        {
			var vmTasks = _taskOrchestrator.OrchestratorGetTasks (_currentUser);

			return View (vmTasks);
        }

		[HttpPost]
		public ActionResult CreateTask(string content)
		{
			_taskOrchestrator.OrchestratorCreateTask (_currentUser, content);

			return RedirectToAction ("Index");
		}

		public TasksController(TasksOrchestrator taskOrchestrator, IUserContext userContext)
		{
			_taskOrchestrator = taskOrchestrator;
			_currentUser = userContext.User;
		}
    }
}