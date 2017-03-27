using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	public class TempQueryResult
	{
		public ITask Task { get; set; }
		public string ListName { get; set; }
	}

	// TODO not sure what to do with this yet
	public class TempFactory : IFromDataReaderFactory<KeyValuePair<int, TempQueryResult>>
	{
		TaskFactory _taskFactory;

		public TempFactory(TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
		}

		public KeyValuePair<int, TempQueryResult> Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new NullReferenceException(nameof(reader));

			// key
			int listId = reader.GetInt("listId");

			// Query Result Object
			int taskId = reader.GetInt("taskId");
			string listName = reader.GetString("listName");
			string taskContent = reader.GetString("taskContent");

			var tempQueryResult = new TempQueryResult();
			tempQueryResult.Task = new Task(taskId, taskContent, false);
			tempQueryResult.ListName = listName;

			var retVal = new KeyValuePair<int, TempQueryResult>(listId, null);

			return retVal;
		}
	}


	public class TaskListWithTasksFactory //: IFromDataReaderFactory<ITaskListWithTasks>
	{
		TaskFactory _taskFactory;

		public TaskListWithTasksFactory(TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
		}

		public ITaskListWithTasks Build(int id, string listName, IEnumerable<ITask> tasks)
		{

			return new TaskListWithTasks(id, listName, tasks);
		}

		/*public ITaskListWithTasks Build(ISqlDataReader reader)
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
		}*/
	}
}
