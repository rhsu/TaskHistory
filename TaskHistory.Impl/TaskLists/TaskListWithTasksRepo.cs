using System;
using System.Collections.Generic;
using TaskHistory.Api.TaskLists;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListWithTasksRepo : ITaskListWithTasksRepo
	{
		public TaskListWithTasksRepo()
		{
		}

		public IEnumerable<ITaskListWithTasks> Read(int userId, int listId)
		{
			throw new NotImplementedException();
		}
	}
}
