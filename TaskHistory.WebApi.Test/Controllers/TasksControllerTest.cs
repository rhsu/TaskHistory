using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using NUnit.Framework;
using TaskHistory.TestFramework;
using WebApi.Controllers;

namespace TaskHistory.WebApi.Test.Controllers.Tasks
{
	[TestFixture]
	public class TasksControllerTest
	{
		ITestFixturesMinimal _testFixtures;
		TasksController _controller;

		[SetUp]
		public void Init()
		{
			_testFixtures = new TestFixturesMinimal();
			_controller = new TasksController();
		}

		[Test]
		public void Get()
		{
			int userId = _testFixtures.UserId;

			_controller.Request = new HttpRequestMessage();
			_controller.Configuration = new HttpConfiguration();

			var response = _controller.Get(userId) as JsonResult<int>;
			var content = response.Content;
			Assert.AreEqual(userId, content);
		}
	}
}
