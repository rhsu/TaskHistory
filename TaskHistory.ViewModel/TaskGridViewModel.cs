namespace TaskHistory.ViewModel.Tasks
{
	public class TaskGridViewModel
	{
		public int TaskId { get; }
		public string TaskContent { get; }

		public TaskGridViewModel(int taskId, string taskContent)
		{
			TaskId = taskId;
			TaskContent = taskContent;
		}
	}
}