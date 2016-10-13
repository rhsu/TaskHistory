using System.Web.Mvc;

namespace TaskHistory.Controllers
{
	[Authorize]
	public class TerminalController : Controller
    {
		[HttpGet]
		public ActionResult Index()
        {
			var responseObj = new TerminalResponseObject("Hello World");

			return View (responseObj);
        }

		[HttpPost]
		public ActionResult Index(TerminalResponseObject responseObject)
		{

			return View(responseObject);
		}

		public ActionResult SubmitCommand(string command)
		{
			// return View("Index");

			var responseObject = new TerminalResponseObject(command);

			return RedirectToAction("Index", new { responseObject });
		}
    }
}
