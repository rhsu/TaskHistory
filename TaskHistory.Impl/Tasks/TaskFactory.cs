using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.Tasks
{
	public class TaskFactory
	{
		public TaskFactory ()
		{
		}

		public ITask CreateTask(int taskId, string content, bool isCompleted)
		{
			return new Task (taskId, content, isCompleted);
		}
	}
}