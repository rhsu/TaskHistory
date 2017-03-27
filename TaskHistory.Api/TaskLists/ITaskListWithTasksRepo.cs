using System.Collections.Generic;

namespace TaskHistory.Api.TaskLists
{
	public interface ITaskListWithTasksRepo
	{
		IEnumerable<ITaskListWithTasks> Read(int userId);
	}
}