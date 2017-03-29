using System;
using NUnit.Framework;
using TaskHistory.Api.History;
using TaskHistory.Api.History.DataTransferObjects;
using TaskHistory.Impl.History;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class HistoryRepoTest
	{
		ApplicationDataProxy _dataProxy;
		HistoryFactory _factory;

		IHistoryRepo _repo;
		TestFixtures _testFixtures;

		[SetUp]
		public void Init()
		{
			_dataProxy = new ApplicationDataProxyFactory().Build();
			_factory = new HistoryFactory();

			_testFixtures = new TestFixtures();

			_repo = new HistoryRepo(_factory, _dataProxy);
		}

		[Test]
		public void Create()
		{
			var parameters = CreateParams(BusinessAction.Create,
			                              BusinessObject.Task);

			var history = _repo.Create(_testFixtures.User.Id, parameters);

			Assert.AreEqual(BusinessAction.Create, history.Action);
			Assert.AreEqual(BusinessObject.Task, history.Object);
			Assert.AreEqual(_testFixtures.User.Id, history.UserId);

			DateTime expectedDateTime = DateTime.UtcNow;
			DateTime actualDateTime = history.ActionDate;

			Assert.AreEqual(expectedDateTime.Month, actualDateTime.Month);
			Assert.AreEqual(expectedDateTime.Day, actualDateTime.Day);			
			Assert.AreEqual(expectedDateTime.Year, actualDateTime.Year);
		}

		static HistoryCreationParams CreateParams(BusinessAction action,
		                                          BusinessObject obj)
		{
			return new HistoryCreationParams(action,
											 obj);
		}
	}
}
