using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using NUnit.Framework;
using WebApi.Controllers;

namespace TaskHistory.WebApi.Test.Controllers
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void GetTest()
		{
			var controller = new HomeController();
			controller.Request = new HttpRequestMessage();
			controller.Configuration = new HttpConfiguration();

			var response = controller.GetTest() as JsonResult<string>;
			var content = response.Content;
			Assert.AreEqual("Hello World", content);
		}
	}
}
