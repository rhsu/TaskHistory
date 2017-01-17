using System.Collections.Generic;
using TaskHistory.Api.Lists;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskLists : ITaskLists
	{
		public int Id { get; }
		public string Name { get; }
		public IEnumerable<ITask> Tasks { get; }

		public TaskLists(int id, string name, IEnumerable<ITask> tasks)
		{
			this.Id = id;
			this.Name = name;
			this.Tasks = tasks;
		}
	}
}