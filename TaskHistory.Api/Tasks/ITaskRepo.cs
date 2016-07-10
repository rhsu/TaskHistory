using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Tasks
{
	public interface ITaskRepo
	{
		ITask CreateNewTaskForUser (IUser user, string taskContent);
		IEnumerable<ITask> ReadTasksForUser(IUser user);
		void UpdateTask (TaskUpdatingParameters taskUpdatingParameters);
		void DeleteTask (int taskId);
	}
}