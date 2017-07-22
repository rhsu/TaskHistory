using NUnit.Framework;
using System;
using WebApi.Controllers;
using System.Web.Http.Results;
using System.Net.Http;
using System.Web.Http;

namespace TaskHistory.WebApi.Test
{
	[TestFixture()]
	public class Test
	{
		[Test]
		public void TestCase()
		{
			var controller = new HomeController();
			controller.Request = new HttpRequestMessage();
			controller.Configuration = new HttpConfiguration();

			var response = controller.GetTest();
			//var val = response.Content.Value;
			var a = response as JsonResult<string>;
			var b = a.Content;


		}
	}
}
