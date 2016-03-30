using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Tasks
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