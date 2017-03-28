using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.TaskLists.QueryResults
{
	public class TaskListWithTasksQueryResult
	{
		public ITask Task { get; set; }
		public string ListName { get; set; }
	}
}