using System.Web.Http;

namespace WebApiTest.Controllers
{
	public class HomeController : ApiController
	{
		public IHttpActionResult GetTest()
		{
			return Json("Hello World");
		}
	}
}