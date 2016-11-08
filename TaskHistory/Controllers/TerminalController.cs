using System.Web.Mvc;
using TaskHistoryOrchestrator;

namespace TaskHistory.Controllers
{
	[Authorize]
	public class TerminalController : ApplicationController
	{
		readonly TerminalOrchestrator _terminalOrchestrator;

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

		public TerminalController(TerminalOrchestrator terminalOrchestrator, ApplicationContext appContext)
			:base(appContext)
		{
			_terminalOrchestrator = terminalOrchestrator;
		}
	}
}