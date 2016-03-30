namespace TaskHistory.Api.Tasks
{
	public interface ITask
	{
		int TaskId { get; }
		string Content { get; }
		bool IsCompleted { get; }
	}
}