using System.Collections.Generic;
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
		IUser _user;

		public Tasks()
		{
			var taskFactory = new TaskFactory();
			var appDataProxyFactory = new ApplicationDataProxyFactory();

			_testFixtures = new TestFixtures();
			_taskRepo = new TaskRepo(taskFactory, appDataProxyFactory.Build());

			_user = _testFixtures.User;
		}

		[Test]
		public void CreateTask()
		{
			string taskContent = "Content of my task";
			int userId = _user.UserId;

			var newtask = _taskRepo.CreateTask(taskContent, userId);

			Assert.AreEqual(taskContent, newtask.Content);

			// TODO: Objects returned from database do not have a UserId
			// Do I care?
			// Assert.AreEqual(userId, newtask.UserId);
		}

		[Test]
		public void ReadTasks()
		{
			// TODO need to rethink this
			//      this is an issue because the user might have tasks
			//      depending on whether or not the previous test ran
			//      The temporary solution is just to create a new TestFixture
			//      and go from there.
			var readTestFixture = new TestFixtures();
			var user = readTestFixture.User;

			var lookup = new Dictionary<int, string>();

			for (var i = 0; i < 5; i++)
			{
				var taskContent = $"task{i}";
				var newTask = _taskRepo.CreateTask(taskContent, user.UserId);
				lookup.Add(newTask.TaskId, taskContent);
			}

			var tasks = _taskRepo.ReadTasks(user.UserId);

			for (var i = 0; i < 5; i++)
			{
				var taskContent = $"task{i}";
				var foundTask = tasks.Where(t => t.Content == $"task{i}").First();

				Assert.AreEqual(taskContent, lookup[foundTask.TaskId]);
			}
		}

		[Test]
		public void UpdateTasksContent()
		{
			string newText = "New Text 123345";

			var updateParams = new TaskUpdatingParameters(newText, false, false);
			var taskId = _testFixtures.Task.TaskId;
			var userId = _testFixtures.User.UserId;

			var updated = _taskRepo.UpdateTask(updateParams, userId, taskId);

			Assert.AreEqual(newText, updated.Content);
			Assert.AreEqual(taskId, updated.TaskId);
		}

		[Test]
		public void UpdateTaskDeleted()
		{
			// TODO: once I can run adhoc select queries then
			//       this test becomes more meaningful as I can
			//       SELECT * FROM tasks WHERE TaskId = `@taskId`
			//       and then assert that the content and is updated
			//       contains correct value
			//       but until I have that infrastructure, I will have to settle
			//       for Lync

			//also assert that the ReadWillNot retrieve deleted tasks
		}
	}
}
