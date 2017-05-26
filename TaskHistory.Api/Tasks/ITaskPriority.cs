namespace TaskHistory.Api.Tasks
{
	public interface ITaskPriority
	{
		int Id { get; }
		int UserId { get; }
		int Rank { get; }
		string Name { get; }
	}
}