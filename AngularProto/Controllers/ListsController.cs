using System.Web.Mvc;

namespace AngularProto.Controllers
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
