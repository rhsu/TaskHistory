namespace TaskHistory.Api.TaskLists.DataTransferObjects
{
	public class TaskListUpdatingParameters
	{
		public string listName { get; }
		public bool isDeleted { get; }

		public TaskListUpdatingParameters(string listName, bool isDeleted)
		{
			this.listName = listName;
			this.isDeleted = isDeleted;
		}
	}
}