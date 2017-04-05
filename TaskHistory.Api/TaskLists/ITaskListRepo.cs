using System.Collections.Generic;

namespace TaskHistory.Api.TaskLists
{
	public interface ITaskListRepo
	{
		IEnumerable<ITaskList> ReadAll(int userId);

		ITaskList Read(int userId, int listId);

		ITaskList Create(int userId, string content);
	}
}