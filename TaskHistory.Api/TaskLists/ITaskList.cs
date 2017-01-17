using System.Collections.Generic;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.TaskLists
{
	public class ITaskList
	{
		public int Id { get; }
		public string Name { get; }

		// public IEnumerable<ITask> Tasks { get; }
	}
}