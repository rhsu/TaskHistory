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
		public void UpdateTasksContent()
		{
			string oldText = "oldText";
			string newText = "newText";
			//1. create a specific task with Content == "test content"
			var newTask =_taskRepo.CreateTask(oldText, _user.UserId);
			//2. perform an update
			var updateParams = new TaskUpdatingParameters(newText, false, false);
			_taskRepo.UpdateTask(updateParams, _user.UserId, newTask.TaskId);

			//3. check that the content is updated
			// Assert.Equals(oldText, newTask.Content);
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
