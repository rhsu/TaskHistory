using System.Collections.Generic;

namespace TaskHistory.Api.Tasks
{
	public interface ITaskRepo
	{
		ITask CreateTask(int userId, string taskContent);

		IEnumerable<ITask> ReadAll(int userId);

		ITask CreateTaskOnList(int userId, int listId, string content);

		ITask UpdateTask(int userId,
						 TaskUpdatingParameters taskUpdatingParameters, 
		                 int taskId);
	}
}