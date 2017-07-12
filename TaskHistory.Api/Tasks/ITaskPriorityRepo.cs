namespace TaskHistory.Api.Tasks
{
	public interface ITaskPriorityRepo
	{
		ITaskPriority Create();
		ITaskPriority Read();
		ITaskPriority Update();
		ITaskPriority Delete();
	}
}