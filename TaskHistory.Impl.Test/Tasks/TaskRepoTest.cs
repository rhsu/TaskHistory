using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class Tasks
	{
		TestFixtures _testFixtures;
		ITaskRepo _taskRepo;
		IUser _user1;

		public Tasks()
		{
			var taskFactory = new TaskFactory();
			var appDataProxyFactory = new ApplicationDataProxyFactory();

			_testFixtures = new TestFixtures();
			_taskRepo = new TaskRepo(taskFactory, appDataProxyFactory.Build());

			_user1 = _testFixtures.User;
		}

		[Test]
		public void CreateTask()
		{
			string taskContent = "Content of my task";
			int userId = _user1.UserId;

			var newtask = _taskRepo.CreateTask(taskContent, userId);

			Assert.AreEqual(taskContent, newtask.Content);
			Assert.AreEqual(userId, newtask.TaskId);
		}

		[Test]
		public void ReadTasks()
		{
			// TODO need to rethink this
			var readTestFixture = new TestFixtures();

			var user = readTestFixture.User;

			for (var i = 0; i < 5; i++)
			{
				_taskRepo.CreateTask($"task{i}", user.UserId);
			}

			var tasks = _taskRepo.ReadTasks(user.UserId); //.ToList();

			Assert.AreEqual(5, tasks.Count());

			for (var i = 0; i < 5; i++)
			{
				Assert.True(tasks.Any(t => t.Content == $"task{i}"));
			}
		}

		[Test]
		public void UpdateTasks()
		{
		}
	}
}
