using System.Collections.Generic;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.TaskLists
{
	public interface ITaskList
	{
		int Id { get; }
		string Name { get; }

		// public IEnumerable<ITask> Tasks { get; }
	}
}