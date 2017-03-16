namespace TaskHistory.Api.Tasks
{
	public interface ITask
	{
		int Id { get; }
		string Content { get; }
		bool IsCompleted { get; }
	}
}