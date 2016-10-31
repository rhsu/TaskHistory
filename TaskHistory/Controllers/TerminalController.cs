using System.Web.Mvc;
using TaskHistory.Api.Users;
using TaskHistoryOrchestrator;

namespace TaskHistory.Controllers
{
	[Authorize]
	public class TerminalController : Controller
    {
		TerminalOrchestrator _terminalOrchestrator;
		IUser _currentUser;

		[HttpGet]
		public ActionResult Index()
        {
			var responseObj = new TerminalResponseObject(_terminalOrchestrator.GetDefaultDisplayMessage());
			return View (responseObj);
        }

		[HttpPost]
		public ActionResult Index(TerminalResponseObject responseObject)
		{
			return View(responseObject);
		}

		[HttpPost]
		public ActionResult SubmitCommand(string command)
		{
			string response = _terminalOrchestrator.ProcessCommand(command, _currentUser);
			var responseObject = new TerminalResponseObject(response);

			return View("Index", responseObject);
		}

		public TerminalController(TerminalOrchestrator terminalOrchestrator, UserContext userContext)
		{
			_terminalOrchestrator = terminalOrchestrator;
			_currentUser = userContext.CurrentUser;
		}
    }
}