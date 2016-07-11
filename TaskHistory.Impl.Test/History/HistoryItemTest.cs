using System;
using NUnit.Framework;
using TaskHistory.Api.History;
using TaskHistory.Impl.History;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class HistoryItemTest
	{
		private const int historyId = 12;
		private readonly DateTime actionDate = new DateTime (2001, 1, 1);
		private const ActionType actionDone = ActionType.Create;
		private const BusinessObjectType businessObjType = BusinessObjectType.Labels;
		private const int userId = 34;
		private const string userName = "User12";

		private HistoryItem objectUnderTest;

		[SetUp]
		public void SetUp()
		{
			objectUnderTest = new HistoryItem (historyId,
				actionDate,
				actionDone,
				businessObjType,
				userId,
				userName);
		}

		[Test]
		public void ConstructorTest()
		{
			Assert.NotNull (objectUnderTest);
		}
			
		[Test]
		public void HistoryIdAccTest()
		{
			Assert.AreEqual (objectUnderTest.HistoryId, historyId);
		}

		[Test]
		public void ActionDateAccTest()
		{
			Assert.AreEqual (objectUnderTest.ActionDate, actionDate);
		}

		[Test]
		public void ActionDoneAccTest()
		{
			Assert.AreEqual (objectUnderTest.ActionDone, actionDone);
		}

		[Test]
		public void BusinessObjectAccTest()
		{
			Assert.AreEqual (objectUnderTest.BusinessObject, businessObjType);
		}

		[Test]
		public void UserIdAccTest()
		{
			Assert.AreEqual (objectUnderTest.UserId, userId);
		}

		[Test]
		public void UserNameAccTest()
		{
			Assert.AreEqual (objectUnderTest.UserName, userName);
		}
	}
}

