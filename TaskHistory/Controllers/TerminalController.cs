using System.Web.Mvc;
using TaskHistory.Api.Users;
using TaskHistoryOrchestrator;

namespace TaskHistory.Controllers
{
	[Authorize]
	public class TerminalController : Controller
    {
		private TerminalOrchestrator _terminalOrchestrator;

		[HttpGet]
		public ActionResult Index()
        {
			var responseObj = new TerminalResponseObject("Hello");

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
			IUser currentUser = (IUser)Session["CurrentUser"];
			string response = _terminalOrchestrator.ProcessCommand(command, currentUser);
			var responseObject = new TerminalResponseObject(response);

			return View("Index", responseObject);
		}

		public TerminalController(TerminalOrchestrator terminalOrchestrator)
		{
			_terminalOrchestrator = terminalOrchestrator;
		}
    }
}