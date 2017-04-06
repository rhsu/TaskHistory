using System.Collections.Generic;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskList : ITaskList
	{
		public int ListId { get; }

		public string ListName { get; }

		public bool IsDeleted { get; }

		public IEnumerable<ITask> Tasks { get; }

		public TaskList(int listId, string listName, bool isDeleted, IEnumerable<ITask> tasks)
		{
			ListId = listId;
			ListName = listName;
			Tasks = tasks;
			IsDeleted = isDeleted;
		}
	}
}
