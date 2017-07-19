namespace TaskHistory.Api.TaskPriorities
{
	public interface ITaskPriorityUpdateParams
	{
		string Name { get; }
		int Rank { get; }
		bool IsDeleted { get; }
	}
}
