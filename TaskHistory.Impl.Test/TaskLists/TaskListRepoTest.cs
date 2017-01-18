using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Users;
using TaskHistory.Impl.TaskLists;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TaskListRepoTest
	{
		ITaskListRepo _taskListRepo;
		TestFixtures _testFixtures;

		public TaskListRepoTest()
		{
			var factory = new TaskListFactory();
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_testFixtures = new TestFixtures();
			_taskListRepo = new TaskListRepo(factory, appDataProxy);
		}

		[Test]
		public void Create()
		{
			IUser user = _testFixtures.User;
			string listName = "My List";

			ITaskList taskList = _taskListRepo.Create(user.UserId, listName);

			Assert.AreEqual(listName, taskList.Name);
		}

		[Test]
		public void Read()
		{
			var readTestFixtures = new TestFixtures();
			var user = readTestFixtures.User;

			var lookup = new Dictionary<int, string>();

			for (var i = 0; i < 5; i++)
			{
				var listName = $"list{i}";
				var newList = _taskListRepo.Create(user.UserId, listName);
				lookup.Add(newList.Id, newList.Name);
			}

			var lists = _taskListRepo.Read(user.UserId);

			for (var i = 0; i < 5; i++)
			{
				var listName = $"list{i}";
				var foundList = lists.Where(l => l.Name == listName).First();

				Assert.AreEqual(listName, lookup[foundList.Id]);
			}
		}

		[Test]
		public void Update()
		{
			ITaskList taskList = _testFixtures.TaskList;
			var newName = "Some New Name 123456";

			ITaskList updated = _taskListRepo.Update(_testFixtures.User.UserId, taskList.Id, newName);

			// Assert.AreEqual(taskList.Id, updated.Id);
			Assert.AreEqual(newName, updated.Name);
		}
	}
}