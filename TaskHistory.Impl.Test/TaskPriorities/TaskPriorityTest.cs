using NUnit.Framework;
using TaskHistory.Api.TaskPriorities;
using TaskHistory.Impl.TaskPriorities;

namespace TaskHistory.Impl.Test.TaskPriorities
{
	[TestFixture]
	public class TaskPriorityTest
	{
		ITaskPriorityRepo _repo;
		TaskPriorityFactory _factory;
		TestFixtures _fixtures;

		[SetUp]
		public void Init()
		{
			var dataProxy = new ApplicationDataProxyFactory().Build();

			_factory = new TaskPriorityFactory();
			_repo = new TaskPriorityRepo(_factory, dataProxy);

		}

		[Test]
		public void Create()
		{
			var userId = _fixtures.User.Id;
			var name = "high";
			var rank = 0;

			ITaskPriority priority = _repo.Create(userId, name, 0);

			Assert.AreEqual(userId, priority.UserId);
			Assert.AreEqual(name, priority.Name);
			Assert.AreEqual(rank, priority.Rank);
		}

		[Test]
		public void Read()
		{
			// try to read from test fixture.
			// this test only makes sense once TaskPriority is successfully a testFixture
			var userId = _fixtures.User.Id;
			var priorities = _repo.Read(userId);

			// TODO assert that _fixtures.Priority is the same as the priorities.First
		}

		[Test]
		public void Update()
		{
			int rank = 999;
			string name = "new name";

			// TODO assert that _fixtures.Priority.name and .rank 
			// 		are not the same as rank and name

			int priorityId = 1; // TODO use the id of _fixutres.Priority.Id;

			int userId = _fixtures.User.Id;
			var updated = _repo.Update(userId, name, rank);

			// TODO not ready yet.
			/*Assert.AreEqual(rank, _fixtures.Priority.Rank);			
			Assert.AreEqual(name, _fixtures.Priority.name);
			Assert.AreEqual(userId, _fixtures.Priority.UserId);*/
		}
	}
}
