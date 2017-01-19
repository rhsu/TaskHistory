using System.Collections.Generic;

namespace TaskHistory.Api.Tasks
{
	//TODO: Can UserId come from a context object?
	public interface ITaskRepo
	{
		ITask CreateTask(string taskContent, int userId);

		ITask CreateTaskOnList(int userId, int listId, string content);

		IEnumerable<ITask> ReadTasks(int userId);

		ITask UpdateTask(TaskUpdatingParameters taskUpdatingParameters, int userId, int taskId);

		void DeleteTask_OLD(int taskId, int userId);

		bool UpdateIsDeleted(int taskId, int userId, bool isDeleted);
	}
}