namespace TaskHistory.ViewModel.TaskLists
{
	public class TaskListEditViewModel
	{
		public string Name { get; }
		public bool IsDeleted { get; }

		public TaskListEditViewModel(string name, bool isDeleted)
		{
			Name = name;
			IsDeleted = isDeleted;
		}
	}
}
