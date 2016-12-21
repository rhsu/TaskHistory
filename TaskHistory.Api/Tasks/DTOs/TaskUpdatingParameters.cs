namespace TaskHistory.Api.Tasks
{
	public class TaskUpdatingParameters
	{
		public string Content { get; }
		public bool IsCompleted { get; }
		public bool IsDeleted { get; }

		public TaskUpdatingParameters(string content, bool isCompleted,bool isDeleted)
		{
			this.Content = content;
			this.IsCompleted = isCompleted;
			this.IsDeleted = isDeleted;
		}
	}
}