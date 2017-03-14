using System.Web.Mvc;
using TaskHistory.Api.Users;

namespace TaskHistory.WebApp.Controllers
{
	public abstract class ApplicationController : Controller
	{
		protected readonly IUser _currentUser;

		public ApplicationController(ApplicationContext appContext)
		{
			_currentUser = appContext.CurrentUser;
		}
	}
}