using System.Collections.Generic;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.TaskLists
{
	public interface ITaskList
	{
		int ListId { get; }
		string ListName { get; }
		bool IsDeleted { get; }

		IEnumerable<ITask> Tasks { get; }
	}
}
