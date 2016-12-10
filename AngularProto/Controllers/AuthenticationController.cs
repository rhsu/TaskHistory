using System.Web.Mvc;
using TaskHistory.Orchestrator.Home;
using TaskHistory.ViewModel.Users;

namespace AngularProto.Controllers
{
    public class AuthenticationController : Controller
    {
		//TODO refator this to Authentication Orchestrator
		readonly HomeOrchestrator _homeOrchestrator;
		
		[HttpPost]
        public JsonResult Login(UserLoginViewModel userLoginViewModel)
		{
			return Json(_homeOrchestrator.OrchestrateValidateUser(userLoginViewModel));
        }

		public AuthenticationController(HomeOrchestrator homeOrchestrator)
		{
			_homeOrchestrator = homeOrchestrator;
		}
    }
}