using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Test.Tasks
{
	[TestFixture]
	public class Tasks
	{
		TestFixtures _testFixtures;
		ITaskRepo _taskRepo;
		IUser _user;

		[SetUp]
		public void Init()
		{
			var taskFactory = new TaskFactory();

			var appDataProxyFactory = new ApplicationDataProxyFactory();
			var appDataProxy = appDataProxyFactory.Build();

			_testFixtures = new TestFixtures();
			_taskRepo = new TaskRepo(taskFactory, appDataProxy);

			_user = _testFixtures.User;
		}

		[Test]
		public void CreateTask()
		{
			string taskContent = "Content of my task";
			int userId = _user.Id;

			var newtask = _taskRepo.CreateTask(userId, taskContent);

			Assert.AreEqual(taskContent, newtask.Content);
		}

		[Test]
		public void ReadTasks()
		{
			var lookup = new Dictionary<int, string>();

			for (var i = 0; i < 5; i++)
			{
				var taskContent = $"task{i}";
				var newTask = _taskRepo.CreateTask(_user.Id, taskContent);
				lookup.Add(newTask.Id, taskContent);
			}

			var tasks = _taskRepo.ReadAll(_user.Id);

			for (var i = 0; i < 5; i++)
			{
				var taskContent = $"task{i}";
				var foundTask = tasks.Where(t => t.Content == $"task{i}").First();

				Assert.AreEqual(taskContent, lookup[foundTask.Id]);
			}
		}

		[Test]
		public void UpdateTasksContent()
		{
			string newText = "New Text 123345";

			var updateParams = new TaskUpdatingParameters(newText, false, false);
			var taskId = _testFixtures.Task.Id;
			var userId = _testFixtures.User.Id;

			var updated = _taskRepo.UpdateTask(userId, updateParams, taskId);

			Assert.AreEqual(newText, updated.Content);
			Assert.AreEqual(taskId, updated.Id);
		}

		[Test]
		public void CreateTaskOnList_Works()
		{
			var userId = _testFixtures.User.Id;
			var listId = _testFixtures.TaskList.ListId;
			var content = "test content here";

			ITask task = _taskRepo.CreateTaskOnList(userId, listId, content);

			Assert.AreEqual(content, task.Content);
		}

		[Test]
		public void CreateTaskOnList_NoList()
		{
			var userId = _testFixtures.User.Id;

			ITask task = _taskRepo.CreateTaskOnList(userId, -1, "Some Content Here");
			Assert.Null(task);
		}

		[Test]
		public void CreateTaskOnList_NoUser()
		{
			var listId = _testFixtures.TaskList.ListId;

			ITask task = _taskRepo.CreateTaskOnList(-1, listId, "Some Content Here");
			Assert.Null(task);
		}

		// TODO This is not ready yet.
		//[Test]
		public void CreateTaskOnList_AlreadyExists()
		{
			// 3. this relationship already exists

			var userId = _testFixtures.User.Id;
			var listId = _testFixtures.TaskList.ListId;
			var content = "test content here";

			ITask task = _taskRepo.CreateTaskOnList(userId, listId, content);

			ITask secondAttempt = _taskRepo.CreateTaskOnList(userId, listId, content);
			// TODO this is not ready yet
			//Assert.Null(secondAttempt);
		}
	}
}
