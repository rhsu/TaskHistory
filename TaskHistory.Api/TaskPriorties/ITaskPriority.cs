namespace TaskHistory.Api.TaskPriorities
{
	public interface ITaskPriority
	{
		int Id { get; }
		int UserId { get; }
		int Rank { get; }
		string Name { get; }
	}
}