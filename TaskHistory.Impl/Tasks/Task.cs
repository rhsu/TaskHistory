using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Tasks
{
	public class Task : ITask
	{
		public int Id { get; }
		public int UserId { get; }
		public int TaskPriorityId { get; }
		public string Content { get; }
		public bool IsCompleted { get; }

		internal Task (int taskId, int userId, int taskPriorityId, string content, bool isCompleted)
		{
			this.Id = taskId;
			this.UserId = userId;
			this.TaskPriorityId = taskPriorityId;
			this.Content = content;
			this.IsCompleted = isCompleted;
		}
	}
}