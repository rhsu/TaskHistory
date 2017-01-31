using System.Collections.Generic;

namespace TaskHistory.Api.Tasks
{
	//TODO: Can UserId come from a context object?
	public interface ITaskRepo
	{
		ITask CreateTask(string taskContent, int userId);

		IEnumerable<ITask> ReadTasks(int userId);

		ITask UpdateTask(TaskUpdatingParameters taskUpdatingParameters, int userId, int taskId);

		void DeleteTask_OLD(int taskId, int userId);

		bool UpdateIsDeleted(int taskId, int userId, bool isDeleted);


		ITask CreateTaskOnList(int userId, int listId, string content);

		bool AssociateTaskToList(int userId, int taskId, int listId);
	}
}