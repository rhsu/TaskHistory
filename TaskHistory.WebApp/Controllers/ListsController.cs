using System.Web.Mvc;

namespace TaskHistory.WebApp.Controllers
{
	public class ListsController : Controller
    {
		[HttpGet]
        public ActionResult Index()
        {
            return View ();
        }
    }
}
