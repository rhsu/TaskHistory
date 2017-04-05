using System.Collections.Generic;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskList : ITaskList
	{
		int _id;
		string _name;
		IEnumerable<ITask> _tasks;

		public TaskList(int id, string name, IEnumerable<ITask> tasks)
		{
			_id = id;
			_name = name;
			_tasks = tasks;
		}

		public int ListId
		{
			get { return _id; }
		}

		public string ListName
		{
			get { return _name; }
		}

		public IEnumerable<ITask> Tasks
		{
			get { return _tasks; }
		}
	}
}
