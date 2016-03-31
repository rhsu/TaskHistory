using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Tasks
{
	public interface ITaskRepo
	{
		ITask InsertNewTask (string taskContent);
		void DeleteTask (int taskId);
		void UpdateTask (ITask newTaskDto);
		IEnumerable<ITask> GetTasksForUser(IUser user);
	}
}