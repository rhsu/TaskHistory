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
		ITaskListRepo _listRepo;

		[SetUp]
		public void Init()
		{
			var taskFactory = new TaskFactory();
			var listFactory = new TaskListFactory();

			var factory = new TaskListWithTasksFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_testFixtures = new TestFixtures();
			_repo = new TaskListWithTasksRepo(factory, appDataProxy);

			_taskRepo = new TaskRepo(taskFactory, appDataProxy);
			_listRepo = new TaskListRepo(listFactory, appDataProxy);
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

			var listsWithTasks = _repo.Read(userId);

			var actualTasks = listsWithTasks.First().Tasks;

			for (var i = 0; i < actualTasks.Count(); i++)
			{
				var currentTask = actualTasks.ElementAt(i);
				var expectedTask = expectedTasks[currentTask.Id];

				Assert.AreEqual(expectedTask.Id, currentTask.Id);				
				Assert.AreEqual(expectedTask.Content, currentTask.Content);
			}
		}

		[Test]
		public void Read_TaskLists_No_Tasks()
		{
			var listsWithTasks = _repo.Read(_testFixtures.User.Id);
			var list = listsWithTasks.First();

			Assert.AreEqual(0, list.Tasks.Count());
		}
	}
}
