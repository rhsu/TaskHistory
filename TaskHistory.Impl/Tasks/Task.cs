using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Tasks
{
	public class Task : ITask
	{
		public int Id { get; }
		public string Content { get; }
		public bool IsCompleted { get; }

		internal Task (int taskId, string content, bool isCompleted)
		{
			this.Id = taskId;
			this.Content = content;
			this.IsCompleted = isCompleted;
		}
	}
}