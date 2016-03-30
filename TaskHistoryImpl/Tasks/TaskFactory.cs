using System;
using TaskHistory.Api.Tasks;
using TaskHistoryImpl.Tasks;

namespace TaskHistoryImpl.Tasks
{
	public class TaskFactory
	{
		public TaskFactory ()
		{
		}

		public ITask CreateTask(int taskId, string content, bool isCompleted)
		{
			return new Task (taskId, content, isCompleted);
		}
	}
}