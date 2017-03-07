namespace TaskHistory.Api.TaskLists
{
	public interface ITaskListWithTasksRepo
	{
		ITaskListWithTasks Read(int userId);
	}
}