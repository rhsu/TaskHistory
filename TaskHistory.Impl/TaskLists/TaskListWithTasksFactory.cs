using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListWithTasksFactory : IFromDataReaderFactory<ITaskListWithTasks>
	{
		TaskFactory _taskFactory;

		public TaskListWithTasksFactory(TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
		}

		public ITaskListWithTasks Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new NullReferenceException(nameof(reader));

			var cache = new Dictionary<int, ITask>();



			/*int id = reader.GetInt("Id");
			string name = reader.GetString("Name");

			var tasks = new List<ITask>();

			if (reader.NextResult())
			{
				var task = _taskFactory.Build(reader);
				tasks.Add(task);
			}*/

			//return new TaskListWithTasks(id, name, tasks);

			return null;
		}
	}
}
