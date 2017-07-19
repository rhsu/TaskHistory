using TaskHistory.Api.TaskPriorities;

namespace TaskHistory.Impl.TaskPriorities
{
	public class TaskPriorityUpdateParamsFactory
	{
		public ITaskPriorityUpdateParams Build(string name,
											   bool isDeleted,
											   int rank)
		{
			return new TaskPriorityUpdateParams(name, isDeleted, rank);
		}
	}
}
