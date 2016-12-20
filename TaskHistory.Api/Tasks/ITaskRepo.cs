using System.Collections.Generic;

namespace TaskHistory.Api.Tasks
{
	//TODO: Can UserId come from a context object?
	public interface ITaskRepo
	{
		ITask CreateTask(string taskContent, int userId);

		IEnumerable<ITask> ReadTasks(int userId);

		void UpdateTask(TaskUpdatingParameters taskUpdatingParameters, int userId);

		void DeleteTask(int taskId, int userId);

		bool SetTaskStatus(int taskId, int userId, bool status);
	}
}