using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Test.TaskLists
{
	[TestFixture]
	public class TaskListWithTasksRepoTest
	{
		ITaskListWithTasksRepo _repo;
		TestFixtures _testFixtures;

		ITaskRepo _taskRepo;

		[SetUp]
		public void Init()
		{
			var taskFactory = new TaskFactory();

			var factory = new TaskListWithTasksFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_testFixtures = new TestFixtures();
			_repo = new TaskListWithTasksRepo(factory, appDataProxy);

			_taskRepo = new TaskRepo(taskFactory, appDataProxy);
		}

		[Test]
		public void Read_All_TaskList_With_Tasks()
		{
			int userId = _testFixtures.User.Id;
			int listId = _testFixtures.TaskList.Id;
			// create 5 tasks and associate them to the existing testFixture list
			var expectedTasks = new Dictionary<int, ITask>();

			for (var i = 0; i < 5; i++)
			{
				var t = _taskRepo.CreateTaskOnList(userId, listId, $"task ${i}");
				expectedTasks.Add(t.Id, t);
			}

			var listsWithTasks = _repo.ReadAll(userId);

			var actualTasks = listsWithTasks.First().Tasks;

			foreach (var task in actualTasks)
			{
				var expectedTask = expectedTasks[task.Id];

				Assert.AreEqual(expectedTask.Id, task.Id);
				Assert.AreEqual(expectedTask.Content, task.Content);
			}
		}

		[Test]
		public void Read_All_TaskLists_No_Tasks()
		{
			var listsWithTasks = _repo.ReadAll(_testFixtures.User.Id);
			var list = listsWithTasks.First();

			Assert.AreEqual(0, list.Tasks.Count());
		}

		[Test]
		public void Read_TaskLists_With_Deleted_Tasks()
		{
			var taskList = _testFixtures.TaskList;
			int userId = _testFixtures.User.Id;

			// create some task on the list
			var task = _taskRepo.CreateTaskOnList(userId, taskList.Id, "Hello World");

			var taskUpdatingParams = new TaskUpdatingParameters(task.Content, 
			                                                    task.IsCompleted, 
			                                                    true);

			var updatedTask = _taskRepo.UpdateTask(userId, taskUpdatingParams, task.Id);

			var listWithTasks = _repo.ReadAll(userId);

			var taskIds = listWithTasks.First().Tasks.Select(x => x.Id);

			Assert.False(taskIds.Contains(updatedTask.Id));
		}

		[Test]
		public void Read_TaskList_With_Tasks()
		{
			int userId = _testFixtures.User.Id;
			int listId = _testFixtures.TaskList.Id;
			// create 5 tasks and associate them to the existing testFixture list
			var expectedTasks = new Dictionary<int, ITask>();

			for (var i = 0; i < 5; i++)
			{
				var t = _taskRepo.CreateTaskOnList(userId, listId, $"task ${i}");
				expectedTasks.Add(t.Id, t);
			}

			var list = _repo.Read(userId, listId);

			Assert.AreEqual(listId, list.ListId);

			var actualTasks = list.Tasks;

			foreach (var task in actualTasks)
			{
				var expectedTask = expectedTasks[task.Id];

				Assert.AreEqual(expectedTask.Id, task.Id);
				Assert.AreEqual(expectedTask.Content, task.Content);
			}
		}

		[Test]
		public void Read_TaskLists_No_Tasks()
		{
			int userId = _testFixtures.User.Id;
			int listId = _testFixtures.TaskList.Id;

			var list = _repo.Read(userId, listId);

			Assert.AreEqual(0, list.Tasks.Count());
		}

		[Test]
		public void Create_TaskList()
		{
			var userId = _testFixtures.User.Id;
			string listName = "Some List Im Buliding";

			var taskList = _repo.Create(userId, listName);

			Assert.AreEqual(listName, taskList.ListName);
			Assert.AreEqual(new List<ITask>(), taskList.Tasks);
		}
	}
}
