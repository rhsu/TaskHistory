using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Tasks
{
	//TODO: IUser user should come from a context object
	public interface ITaskRepo
	{
		ITask CreateNewTaskForUser (IUser user, string taskContent);

		IEnumerable<ITask> ReadTasksForUser(IUser user);

		void UpdateTask (TaskUpdatingParameters taskUpdatingParameters);

		void DeleteTask (int taskId);
	}
}