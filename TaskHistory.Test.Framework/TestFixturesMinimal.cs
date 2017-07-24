using System.Collections.Generic;
using System.Linq;

namespace TaskHistory.TestFramework
{
	public class TestFixturesMinimal : TestFixtures, ITestFixturesMinimal
	{
		public IEnumerable<int> HistoryIds
		{
			get { return this.Histories.Select(x => x.Id); }
		}

		public int TaskId
		{
			get { return this.Task.Id; }
		}

		public int TaskListId
		{
			get { return this.TaskList.ListId; }
		}

		public int TaskPriorityId
		{
			get { return this.TaskPriority.Id; }
		}

		public int UserId
		{
			get { return this.User.Id; }
		}
	}
}
