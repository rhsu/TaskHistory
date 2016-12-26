namespace TaskHistory.Api.Tasks
{
	public interface ITaskListRepo
	{
		// TODO not sure if I will need this
		//IEnumerable<ITask> ReadTasksForList();

		// TODO not sure if I will need this
		//IEnumerable<ITask> ReadTasksForUser();

		ITask CreateTask(int userId, int taskId, string content);

		ITask UpdateTask(int userId, int taskId, TaskUpdatingParameters updateParams);
	}
}
