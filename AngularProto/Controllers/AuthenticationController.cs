using System.Web.Mvc;
using TaskHistory.Orchestrator.Home;

namespace AngularProto.Controllers
{
    public class AuthenticationController : Controller
    {
		//TODO refator this to Authentication Orchestrator
		readonly HomeOrchestrator _homeOrchestrator;
		
		[HttpPost]
        public JsonResult Login()
        {
			return Json("hello world");
        }

		public AuthenticationController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
    }
}