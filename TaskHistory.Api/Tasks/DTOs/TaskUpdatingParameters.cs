namespace TaskHistory.Api.Tasks
{
	public class TaskUpdatingParameters
	{
		public string Content { get; }
		public bool IsCompleted { get; }
		public bool IsDeleted { get; }
		public int TaskId { get; }

		public TaskUpdatingParameters(string content,
			bool isCompleted,
			bool isDeleted,
			int taskId)
		{
		}
	}
}