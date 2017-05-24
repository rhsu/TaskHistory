namespace TaskHistory.Api.Tasks
{
	public interface ITask
	{
		int Id { get; }
		int UserId { get; }
		int PriorityId { get; }
		string Content { get; }
		bool IsCompleted { get; }
	}
}