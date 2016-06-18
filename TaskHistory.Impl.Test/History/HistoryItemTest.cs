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

		private HistoryItem itemUnderTest;

		[SetUp]
		public void Init()
		{
			itemUnderTest = new HistoryItem (historyId,
				actionDate,
				actionDone,
				businessObjType,
				userId,
				userName);
		}

		[Test]
		public void ConstructorTest()
		{
			Assert.NotNull (itemUnderTest);
		}
			
		[Test]
		public void HistoryIdAccTest()
		{
			Assert.Equals (itemUnderTest.HistoryId, historyId);
		}

		[Test]
		public void ActionDateAccTest()
		{
			Assert.Equals (itemUnderTest.ActionDate, actionDate);
		}

		[Test]
		public void ActionDoneAccTest()
		{
			Assert.Equals (itemUnderTest.ActionDone, actionDone);
		}

		[Test]
		public void BusinessObjectAccTest()
		{
			Assert.Equals (itemUnderTest.BusinessObject, businessObjType);
		}

		[Test]
		public void UserIdAccTest()
		{
			Assert.Equals (itemUnderTest.UserId, userId);
		}

		[Test]
		public void UserNameAccTest()
		{
			Assert.Equals (itemUnderTest.UserName, userName);
		}
	}
}

