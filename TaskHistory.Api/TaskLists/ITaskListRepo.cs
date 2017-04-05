using System.Collections.Generic;
using TaskHistory.Api.TaskLists.DataTransferObjects;

namespace TaskHistory.Api.TaskLists
{
	public interface ITaskListRepo
	{
		IEnumerable<ITaskList> ReadAll(int userId);

		ITaskList Read(int userId, int listId);

		ITaskList Create(int userId, string content);

		ITaskList Update(int userId, int id, TaskListUpdatingParameters listUpdatingParams);
	}
}