using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Controllers
{
	public class HomeController : ApiController
	{
		/*public ActionResult Index()
		{
			var mvcName = typeof(Controller).Assembly.GetName();
			var isMono = Type.GetType("Mono.Runtime") != null;

			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";

			return View();
		}*/

		public IHttpActionResult GetTest()
		{
			return Json("Hello World");
		}

		public OkNegotiatedContentResult<string> Hello()
		{
			//var response = Request.CreateResponse(HttpStatusCode.OK, "Hello World");
			//return response;
			return Ok("Hello World");
		}

		public HomeController()
		{
		}
	}
}
