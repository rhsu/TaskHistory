using System.Web.Http;
using System.Web.Mvc;

namespace WebApi.Controllers
{
	public class TasksController : ApiController
    {
		public IHttpActionResult Get(int userId)
		{
			return Json(userId);
		}
    }
}
