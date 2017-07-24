using System.Collections.Generic;

namespace TaskHistory.TestFramework
{
	public interface ITestFixturesMinimal
	{
		int UserId { get; }

		int TaskListId { get; }

		int TaskId { get; }

		IEnumerable<int> HistoryIds { get; }

		int TaskPriorityId { get; }
	}
}
