namespace TaskHistory.ViewModel.Tasks
{
	public class TaskTableViewModel
	{
		public int TaskId { get; }
		public string TaskContent { get; }

		public TaskTableViewModel(int taskId, string taskContent)
		{
			TaskId = taskId;
			TaskContent = taskContent;
		}
	}
}