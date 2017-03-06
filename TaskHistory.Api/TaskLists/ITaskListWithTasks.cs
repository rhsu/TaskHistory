using System.Collections.Generic;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.TaskLists
{
	// TODO possibily have this inherit ITaskList
	//      but currently it doesn't because I can't 
	//      find a good reason for it to
	public interface ITaskListWithTasks
	{
		int Id { get; }
		string Name { get; }

		IEnumerable<ITask> Tasks { get; }
	}
}
