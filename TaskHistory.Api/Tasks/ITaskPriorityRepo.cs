namespace TaskHistory.Api.Tasks
{
	public interface ITaskPriorityRepo
	{
		ITaskPriority Create(int userId, string name);
		ITaskPriority Read();
		ITaskPriority Update();
		ITaskPriority Delete();
	}
}