using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.TaskLists.QueryResults;
using TaskHistory.Impl.Tasks;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListWithTasksFactory : IFromDataReaderFactory<KeyValuePair<int, TaskListWithTasksQueryResult>>
	{
		public KeyValuePair<int, TaskListWithTasksQueryResult> Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new NullReferenceException(nameof(reader));

			// key
			int listId = reader.GetInt("ListId");

			// Query Result Object
			int? taskId = reader.GetNullableInt("TaskId");
			string listName = reader.GetString("ListName");

			bool? isTaskDeleted = reader.GetNullableBool("IsTaskDeleted");

			// TODO how do I use DI here?
			var queryResult = new TaskListWithTasksQueryResult();

			if (taskId.HasValue && (isTaskDeleted == false))
			{
				string content = reader.GetString("TaskContent");

				// TODO how do I use DI here?
				queryResult.Task = new Task(taskId.Value, content, false);
			}

			queryResult.ListName = listName;

			var retVal = new KeyValuePair<int, TaskListWithTasksQueryResult>(listId, queryResult);

			return retVal;
		}
	}
}
