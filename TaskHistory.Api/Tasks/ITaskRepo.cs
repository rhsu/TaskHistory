using System.Collections.Generic;

namespace TaskHistory.Api.Tasks
{
	//TODO: Can UserId come from a context object?
	public interface ITaskRepo
	{
		// TODO not sure if I will need this
		//IEnumerable<ITask> ReadTasksForList();

		// TODO not sure if I will need this
		//IEnumerable<ITask> ReadTasksForUser();

		ITask CreateTask(int userId, int listId, string content);

		ITask UpdateTask(int userId, int taskId, TaskUpdatingParameters updateParams);
	}
}