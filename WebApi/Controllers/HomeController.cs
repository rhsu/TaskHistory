using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Controllers
{
	public class HomeController : ApiController
	{
		public IHttpActionResult GetTest()
		{
			return Json("Hello World");
		}

		// TODO this might be the correct syntax to use but 
		//		I don't understand how it will interact with
		//		Angular 2 yet.
		//		In a Curl Test, I was not able to get a response
		//		I am sticking with Json(_blah) until this is sorted out
		public OkNegotiatedContentResult<string> Hello()
		{
			return Ok("Hello World");
		}
	}
}
