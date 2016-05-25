using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Tasks
{
	public class Task : ITask
	{
		public int TaskId { get; }
		public string Content { get; }
		public bool IsCompleted { get; }

		public Task (int taskId, string content, bool isCompleted)
		{
			this.TaskId = taskId;
			this.Content = content;
			this.IsCompleted = isCompleted;
		}

		public override bool Equals (object obj)
		{
			var taskObj = obj as Task;

			if (taskObj == null)
				return false;

			return ((this.TaskId == taskObj.TaskId)
				&& (this.Content == taskObj.Content)
				&& (this.IsCompleted == taskObj.IsCompleted));
		}
	}
}