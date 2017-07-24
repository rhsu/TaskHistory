using System.Collections.Generic;
using TaskHistory.Api.History;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.TaskPriorities;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;

namespace TaskHistory.TestFramework
{
	public interface ITestFixtures
	{
		IUser User { get; }

		ITaskList TaskList { get; }

		ITask Task { get; }

		IEnumerable<IHistory> Histories { get; }

		ITaskPriority TaskPriority { get; }
	}
}
