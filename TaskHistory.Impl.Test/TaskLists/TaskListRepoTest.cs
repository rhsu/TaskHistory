using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Users;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.Users;

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

		/*public void AssociateTaskToList()
		{
		}*/

		[Test]
		public void Create()
		{
			IUser user = _testFixtures.User;
			string listName = "My List";

			ITaskList taskList = _taskListRepo.Create(user.UserId, listName);

			Assert.AreEqual(listName, taskList.Name);
		}

		/*public void Read()
		{
			
		}*/

		public void Update()
		{
			
		}
	}
}
