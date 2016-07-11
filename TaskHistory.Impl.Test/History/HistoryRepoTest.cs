using System;
using NUnit.Framework;
using TaskHistory.Api.History;
using TaskHistory.Impl.History;
using System.Linq;
using TaskHistory.Impl.Sql;
using Moq;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class HistoryRepoTest
	{
		private IHistoryRepo objectUnderTest;

		[SetUp]
		public void SetUp()
		{
			Mock<ApplicationDataProxy> mockAppDataProxy = new Mock<ApplicationDataProxy> ();
			mockAppDataProxy
				.Setup (dataProxy => dataProxy
									.DataReaderProvider
									.ExecuteReaderForTypeCollection<IHistoryItem> (null, "", new List<ISqlDataParameter>()))
				.Returns (new List<IHistoryItem>());
			//objectUnderTest = new HistoryRepo ();
		}

		[Test]
		public void ReadHistoryForUserTest()
		{
			// given a userId
			// get back a list of history items
			// in the database, I have a user Id 5, which contains 3 IHistoryItems
			var histories = objectUnderTest.ReadHistoryForUser(5);
			if (histories == null)
				throw new NullReferenceException ("Null returned from object under test");
			
			Assert.AreEqual (3, histories.Count ());
		}
	}
}

