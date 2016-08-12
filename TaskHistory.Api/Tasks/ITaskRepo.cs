using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Tasks
{
	public interface ITaskRepo
	{
		ITask CreateNewTaskForUser (IUser user, string taskContent);
		IEnumerable<ITask> ReadTasksForUser(IUser user);
		//TODO: refactor to an admin repo
		IEnumerable<ITask> ReadAllTasks (int limit);
		void UpdateTask (TaskUpdatingParameters taskUpdatingParameters);
		void DeleteTask (int taskId);
	}
}