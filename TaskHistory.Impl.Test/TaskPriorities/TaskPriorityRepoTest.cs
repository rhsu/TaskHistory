using System.Linq;
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
			_fixtures = new TestFixtures();

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
			var userId = _fixtures.User.Id;
			var priority = _fixtures.TaskPriority;

			var readPriorities = _repo.Read(userId);

			Assert.AreEqual(1, readPriorities.Count());

			var readPriority = readPriorities.First();

			Assert.AreEqual(priority.Id, readPriority.Id);				
			Assert.AreEqual(priority.Name, readPriority.Name);
			Assert.AreEqual(priority.Rank, readPriority.Rank);		
			Assert.AreEqual(priority.UserId, readPriority.UserId);
		}

		[Test]
		public void Update()
		{
			int rank = 999;
			string name = "new name";

			var priority = _fixtures.TaskPriority;
			var id = priority.Id;

			Assert.AreNotEqual(rank, priority.Rank);
			Assert.AreNotEqual(name, priority.Name);
			// TODO assert that _fixtures.Priority.name and .rank 
			// 		are not the same as rank and name

			int userId = _fixtures.User.Id;
			var updated = _repo.Update(userId, id, name, rank);

			Assert.AreEqual(rank, updated.Rank);			
			Assert.AreEqual(name, updated.Name);
			Assert.AreEqual(userId, updated.UserId);
			Assert.AreEqual(id, updated.Id);
		}

		[Test]
		public void Delete()
		{
			var numDeleted = _repo.Delete(_fixtures.User.Id, _fixtures.TaskPriority.Id);
			Assert.AreEqual(1, numDeleted);
		}
	}
}
