using System;
using TaskHistoryApi.Tasks;
using System.Collections.Generic;
using TaskHistoryImpl.Tasks;

namespace TaskHistoryImpl.TaskRepo
{
	public class TaskRepo : ITaskRepo
	{
		public void CreateTask (ITask task)
		{
			throw new NotImplementedException ();
		}

		public void DeleteTask (int taskId)
		{
			throw new NotImplementedException ();
		}

		public void UpdateTask (int taskId, ITask newTaskDto)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<ITask> GetTasksByUserId (int userId)
		{
			throw new NotImplementedException ();
		}

		public TaskRepo (TaskFactory taskFactory)
		{
		}
	}
}

