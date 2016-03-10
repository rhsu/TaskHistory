using System;
using TaskHistoryApi.Tasks;
using TaskHistoryImpl.Task;

namespace TaskHistoryImpl.Tasks
{
	public class TaskFactory
	{
		public TaskFactory ()
		{
		}

		public ITask createTask(int taskId, string content, bool isCompleted)
		{
			return new Task (taskId, content, isCompleted);
		}
	}
}