using System.Collections.Generic;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.TaskLists
{
	// TODO possibily have this inherit ITaskList
	//      but currently it doesn't because I can't 
	//      find a good reason for it to
	public interface ITaskListWithTasks
	{
		int ListId { get; }
		string ListName { get; }

		IEnumerable<ITask> Tasks { get; }
	}
}
