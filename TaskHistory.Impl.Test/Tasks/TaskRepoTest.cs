using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Test.Tasks
{
	[TestFixture]
	public class Tasks
	{
		TestFixtures _testFixtures;
		ITaskRepo _taskRepo;
		ITaskListRepo _taskListRepo;
		IUser _user;

		public Tasks()
		{
			var taskFactory = new TaskFactory();
			var taskListFactory = new TaskListFactory();

			var appDataProxyFactory = new ApplicationDataProxyFactory();
			var appDataProxy = appDataProxyFactory.Build();

			_testFixtures = new TestFixtures();
			_taskRepo = new TaskRepo(taskFactory, appDataProxy);
			_taskListRepo = new TaskListRepo(taskListFactory, appDataProxy);

			_user = _testFixtures.User;
		}

		[Test]
		public void CreateTask()
		{
			string taskContent = "Content of my task";
			int userId = _user.UserId;

			var newtask = _taskRepo.CreateTask(userId, taskContent);

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
				var newTask = _taskRepo.CreateTask(user.UserId, taskContent);
				lookup.Add(newTask.TaskId, taskContent);
			}

			var tasks = _taskRepo.ReadAll(user.UserId);

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

			var updated = _taskRepo.UpdateTask(userId, updateParams, taskId);

			Assert.AreEqual(newText, updated.Content);
			Assert.AreEqual(taskId, updated.TaskId);
		}

		[Test]
		public void CreateTaskOnList()
		{
			// a lot of things here can fail
			// 1. a list does not exist with that Id
			// 2. the list id is valid but not for that user
			// 3. this relationship already exists

			// in this test, assume that all is good
			var userId = _testFixtures.User.UserId;
			var listId = _testFixtures.TaskList.Id;
			var content = "test content here";

			ITask task = _taskRepo.CreateTaskOnList(userId, listId, content);
			var taskLists = _taskListRepo.Read(userId);
			var taskList = taskLists.Where(x => x.Id == listId).First();

			Assert.AreEqual(content, task.Content);
		}

		/*[Test]
		public void CreateTaskOnList()
		{
		}*/
	}
}
