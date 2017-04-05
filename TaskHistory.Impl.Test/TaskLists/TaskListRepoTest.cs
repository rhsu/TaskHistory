﻿using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Users;
using TaskHistory.Impl.TaskLists;

namespace TaskHistory.Impl.Test.TaskLists
{
	[TestFixture]
	public class TaskListRepoTest
	{
		ITaskListWithTasksRepo _taskListRepo;
		TestFixtures _testFixtures;

		[SetUp]
		public void Init()
		{
			var factory = new TaskListWithTasksFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_testFixtures = new TestFixtures();
			_taskListRepo = new TaskListWithTasksRepo(factory, appDataProxy);
		}

		[Test]
		public void Create()
		{
			IUser user = _testFixtures.User;
			string listName = "My List";

			ITaskListWithTasks taskList = _taskListRepo.Create(user.Id, listName);

			Assert.AreEqual(listName, taskList.ListName);
		}

		/*[Test]
		public void Read()
		{
			var readTestFixtures = new TestFixtures();
			var user = readTestFixtures.User;

			var lookup = new Dictionary<int, string>();

			for (var i = 0; i < 5; i++)
			{
				var listName = $"list{i}";
				var newList = _taskListRepo.Create(user.Id, listName);
				lookup.Add(newList.Id, newList.Name);
			}

			var lists = _taskListRepo.Read(user.Id);

			for (var i = 0; i < 5; i++)
			{
				var listName = $"list{i}";
				var foundList = lists.Where(l => l.Name == listName).First();

				Assert.AreEqual(listName, lookup[foundList.Id]);
			}
		}*/

		/*[Test]
		public void Update()
		{
			ITaskList taskList = _testFixtures.TaskList;
			var newName = "Some New Name 123456";

			ITaskList updated = _taskListRepo.Update(_testFixtures.User.Id, taskList.Id, newName);

			Assert.AreEqual(taskList.Id, updated.Id);
			Assert.AreEqual(newName, updated.Name);
		}*/
	}
}