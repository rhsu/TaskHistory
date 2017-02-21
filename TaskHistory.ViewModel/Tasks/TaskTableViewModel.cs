namespace TaskHistory.ViewModel.Tasks
{
	public class TaskTableViewModel
	{
		public int TaskId { get; }
		public string TaskContent { get; }

		// TODO
		// Add in IsDeleted. 
		// This might be necessary when updating the taskContent of a deletedTask
		// or also allowing the user to view deleted tasks.

		public TaskTableViewModel(int taskId, string taskContent)
		{
			TaskId = taskId;
			TaskContent = taskContent;
		}
	}
}