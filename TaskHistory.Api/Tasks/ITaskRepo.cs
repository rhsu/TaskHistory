using System.Collections.Generic;

namespace TaskHistory.Api.Tasks
{
	//TODO: Can UserId come from a context object?
	public interface ITaskRepo
	{
		// this is outdated
		ITask CreateTask(string taskContent, int userId);

		// This is no longer needed
		IEnumerable<ITask> ReadTasks(int userId);

		ITask UpdateTask(TaskUpdatingParameters taskUpdatingParameters, int userId, int taskId);

		void DeleteTask_OLD(int taskId, int userId);

		bool UpdateIsDeleted(int taskId, int userId, bool isDeleted);

		// TODO not sure if I will need this
		//IEnumerable<ITask> ReadTasksForList();

		// TODO not sure if I will need this
		//IEnumerable<ITask> ReadTasksForUser();

		ITask CreateTask(int userId, int taskId, string content);

		ITask UpdateTask(int userId, int taskId, TaskUpdatingParameters updateParams);
	}
}