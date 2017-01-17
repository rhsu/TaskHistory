using System;
using System.Collections.Generic;
using TaskHistory.Api.TaskLists;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListRepo : ITaskListRepo
	{
		public bool AssociateTasksToList(int userId, int listId, IEnumerable<int> taskIds)
		{
			throw new NotImplementedException();
		}

		public ITaskList Create(int userId, string name)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ITaskList> Read(int userId)
		{
			throw new NotImplementedException();
		}

		public ITaskList Update(int userId, string name)
		{
			throw new NotImplementedException();
		}

		public TaskListRepo()
		{
		}
	}
}
