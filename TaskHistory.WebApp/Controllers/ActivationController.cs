using System.Web.Mvc;
using TaskHistory.Orchestrator;
using TaskHistory.ViewModel.Users;

namespace TaskHistory.WebApp.Controllers
{
	public class ActivationController : Controller
	{
		readonly ActivationOrchestrator _activationOrchestrator;

		[HttpPost]
		public JsonResult Register(UserRegistrationParametersViewModel userRegisterViewModel)
		{
			return Json(_activationOrchestrator.RegisterUser(userRegisterViewModel));
		}

		public ActivationController(ActivationOrchestrator activationOrchestrator)
		{
			_activationOrchestrator = activationOrchestrator;
		}
	}
}