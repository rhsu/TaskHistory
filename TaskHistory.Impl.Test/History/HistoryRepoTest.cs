using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.History;
using TaskHistory.Api.History.DataTransferObjects;
using TaskHistory.Impl.History;
using TaskHistory.Impl.Sql;
using TaskHistory.TestFramework;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class HistoryRepoTest
	{
		ApplicationDataProxy _dataProxy;
		HistoryFactory _factory;

		IHistoryRepo _repo;
		ITestFixtures _testFixtures;

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

			// TODO this should be UTC now but need to patch DB to get that working
			DateTime expectedDateTime = DateTime.Now;
			DateTime actualDateTime = history.ActionDate;

			Assert.AreEqual(expectedDateTime.Month, actualDateTime.Month);
			Assert.AreEqual(expectedDateTime.Day, actualDateTime.Day);			
			Assert.AreEqual(expectedDateTime.Year, actualDateTime.Year);
		}

		[Test]
		public void Create_SomethingElse()
		{
			var parameters = CreateParams(BusinessAction.Read,
										  BusinessObject.TaskList);

			var history = _repo.Create(_testFixtures.User.Id, parameters);

			Assert.AreEqual(BusinessAction.Read, history.Action);
			Assert.AreEqual(BusinessObject.TaskList, history.Object);
			Assert.AreEqual(_testFixtures.User.Id, history.UserId);

			// TODO this should be UTC now but need to patch DB to get that working
			DateTime expectedDateTime = DateTime.Now;
			DateTime actualDateTime = history.ActionDate;

			Assert.AreEqual(expectedDateTime.Month, actualDateTime.Month);
			Assert.AreEqual(expectedDateTime.Day, actualDateTime.Day);
			Assert.AreEqual(expectedDateTime.Year, actualDateTime.Year);
		}

		[Test]
		public void Read()
		{
			var readHistories = _repo.Read(_testFixtures.User.Id).OrderBy(x => x.Id);
			var createdHistories = _testFixtures.Histories.OrderBy(x => x.Id);

			Assert.AreEqual(readHistories.Count(), createdHistories.Count());

			var readHistoryCache = Dictify(readHistories);			
			var createdHistoryCache = Dictify(readHistories);

			foreach (var kvp in readHistoryCache)
			{
				var expected = createdHistoryCache[kvp.Key];
				var actual = kvp.Value;

				Assert.AreEqual(expected.Action, actual.Action);
				Assert.AreEqual(expected.ActionDate, actual.ActionDate);
				Assert.AreEqual(expected.Id, actual.Id);
				Assert.AreEqual(expected.Object, actual.Object);
				Assert.AreEqual(expected.UserId, actual.UserId);
			}
		}

		static IDictionary<int, IHistory> Dictify(IEnumerable<IHistory> histories)
		{
			var retVal = new Dictionary<int, IHistory>();

			foreach (var history in histories)
			{
				retVal.Add(history.Id, history);
			}

			return retVal;
		}

		static HistoryCreationParams CreateParams(BusinessAction action,
		                                          BusinessObject obj)
		{
			return new HistoryCreationParams(action,
											 obj);
		}
	}
}
