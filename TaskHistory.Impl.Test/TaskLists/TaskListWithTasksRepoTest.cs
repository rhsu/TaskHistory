using NUnit.Framework;
using TaskHistory.Api.TaskLists;
using TaskHistory.Impl.TaskLists;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Test.TaskLists
{
	public class TaskListWithTasksRepoTest
	{
		ITaskListWithTasksRepo _repo;
		TestFixtures _testFixtures;

		public TaskListWithTasksRepoTest()
		{
			var factory = new TaskListWithTasksFactory(new TaskFactory());
			var appDataProxy = new ApplicationDataProxyFactory().Build();

			_testFixtures = new TestFixtures();
			_repo = new TaskListWithTasksRepo(factory, appDataProxy);
		}

		[Test]
		public void Read()
		{
			// TODO can't do this yet since I need to associate a couple of tasks to a list
		}
	}
}
