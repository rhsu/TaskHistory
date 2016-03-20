using System;
using System.Collections.Generic;
using TaskHistoryApi.User;

namespace TaskHistoryApi.Tasks
{
	public interface ITaskRepo
	{
		ITask CreateTask (string taskContent);
		void DeleteTask (int taskId);
		void UpdateTask (int taskId, ITask newTaskDto);
		IEnumerable<ITask> GetTasksForUser(IUser user);
	}
}