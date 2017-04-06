using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.TaskLists.DataTransferObjects;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Test.TaskLists
{
	[TestFixture]
	public class TaskListRepoTest
	{
		ITaskListRepo _repo;
		TestFixtures _testFixtures;

		ITaskRepo _taskRepo;

		[SetUp]
		public void Init()
		{
			var taskFactory = new TaskFactory();

			var factory = new TaskListWithTasksFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_testFixtures = new TestFixtures();
			_repo = new TaskListRepo(factory, appDataProxy);

			_taskRepo = new TaskRepo(taskFactory, appDataProxy);
		}

		[Test]
		public void Read_All_TaskList_With_Tasks()
		{
			int userId = _testFixtures.User.Id;
			int listId = _testFixtures.TaskList.ListId;
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
			var task = _taskRepo.CreateTaskOnList(userId, taskList.ListId, "Hello World");

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
			int listId = _testFixtures.TaskList.ListId;
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
			int listId = _testFixtures.TaskList.ListId;

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

		[Test]
		public void Update_TaskList_Delete()
		{
			var userId = _testFixtures.User.Id;
			var name = _testFixtures.TaskList.ListName;
			var listId = _testFixtures.TaskList.ListId;
			var param = new TaskListUpdatingParameters(name, true);

			var updated = _repo.Update(userId, listId, param);

			Assert.AreEqual(listId, updated.ListId);
			Assert.AreEqual(name, updated.ListName);
			Assert.AreEqual(true, updated.IsDeleted);

			var allLists = _repo.ReadAll(userId);
			Assert.True(allLists.Count() == 0);
		}

		[Test]
		public void UpdateTaskList_Name_AND_Not_Deleted()
		{
			var userId = _testFixtures.User.Id;
			var name = "New Name";
			var listId = _testFixtures.TaskList.ListId;
			var param = new TaskListUpdatingParameters(name, false);

			var updated = _repo.Update(userId, listId, param);

			Assert.AreEqual(listId, updated.ListId);
			Assert.AreEqual(name, updated.ListName);
			Assert.AreEqual(false, updated.IsDeleted);

			var allLists = _repo.ReadAll(userId);
			var item = allLists.Select(x => x.ListId == updated.ListId);
			Assert.NotNull(item.First());
		}
	}
}
