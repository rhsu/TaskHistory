using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	// TODO not sure what to do with this yet
	public class TempQueryResult
	{
		public ITask Task { get; set; }
		public string ListName { get; set; }
	}

	public class TaskListWithTasksFactory : IFromDataReaderFactory<KeyValuePair<int, TempQueryResult>>
	{
		TaskFactory _taskFactory;

		public TaskListWithTasksFactory(TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
		}

		public KeyValuePair<int, TempQueryResult> Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new NullReferenceException(nameof(reader));

			// key
			int listId = reader.GetInt("ListId");

			// Query Result Object
			int? taskId = reader.GetInt("TaskId");
			string listName = reader.GetString("ListName");
			string taskContent = reader.GetString("TaskContent");

			var tempQueryResult = new TempQueryResult();

			if (taskId.HasValue)
			{
				tempQueryResult.Task = _taskFactory.Build(reader);
			}

			tempQueryResult.ListName = listName;

			var retVal = new KeyValuePair<int, TempQueryResult>(listId, tempQueryResult);

			return retVal;
		}
	}
}
