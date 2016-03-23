using System;
using System.Collections.Generic;
using TaskHistoryApi.Users;

namespace TaskHistoryApi.Tasks
{
	public interface ITaskRepo
	{
		ITask InsertNewTask (string taskContent);
		void DeleteTask (int taskId);
		void UpdateTask (ITask newTaskDto);
		IEnumerable<ITask> GetTasksForUser(IUser user);
	}
}