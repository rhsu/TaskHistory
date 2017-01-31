using TaskHistory.Api.TaskLists;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskList : ITaskList
	{
		public int Id { get; }
		public string Name { get; }

		public TaskList(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}
