using System.Collections.Generic;

namespace TaskHistory.Api.TaskLists
{
	public interface ITaskListWithTasksRepo
	{
		IEnumerable<ITaskListWithTasks> ReadAll(int userId);

		ITaskListWithTasks Read(int userId, int listId);

		ITaskListWithTasks Create(int userId, string content);
	}
}