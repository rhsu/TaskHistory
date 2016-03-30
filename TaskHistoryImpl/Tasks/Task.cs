using System;
using TaskHistory.Api.Tasks;

namespace TaskHistoryImpl.Tasks
{
	public class Task : ITask
	{
		public int TaskId { get; }
		public string Content { get; }
		public bool IsCompleted { get; }

		internal Task (int taskId, string content, bool isCompleted)
		{
			this.TaskId = taskId;
			this.Content = content;
			this.IsCompleted = isCompleted;
		}
	}
}