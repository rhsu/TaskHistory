using System.Web.Http;

namespace WebApi.Controllers
{
	public class TasksController : ApiController
	{
		// TODO how to route this correctly?
		//		and test it?
		public IHttpActionResult Get(int userId)
		{
			return Json(userId);
		}
	}
}
