namespace TaskHistory.ViewModel.Tasks
{
	/// <summary>
	/// Properties on a task that may be edited
	/// </summary>
	public class TaskEditViewModel
	{
		public string TaskContent { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsCompleted { get; set; }
	}
}
