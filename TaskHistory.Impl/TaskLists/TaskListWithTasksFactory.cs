using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	// TODO not sure what to do with this yet
	public class TempFactory : IFromDataReaderFactory<KeyValuePair<int, ITask>>
	{
		TaskFactory _taskFactory;

		public TempFactory(TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
		}

		public KeyValuePair<int, ITask> Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new NullReferenceException(nameof(reader));

			var retVal = new KeyValuePair<int, ITask>();

			int listId = reader.GetInt("listId");
			int taskId = reader.GetInt("taskId");
			string taskContent = reader.GetString("taskContent");

			return retVal;
		}
	}


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

			int id = reader.GetInt("Id");
			string name = reader.GetString("Name");

			var tasks = new List<ITask>();

			if (reader.NextResult())
			{
				var task = _taskFactory.Build(reader);
				tasks.Add(task);
			}

			return new TaskListWithTasks(id, name, tasks);
		}
	}
}
