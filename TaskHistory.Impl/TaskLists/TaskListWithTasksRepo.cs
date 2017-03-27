using System.Collections.Generic;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListWithTasksRepo : ITaskListWithTasksRepo
	{
		TaskListWithTasksFactory _factory;
		ApplicationDataProxy _dataProxy;

		const string ReadStoredProcedure = "TaskListsWithTasks_Select";

		public TaskListWithTasksRepo(TaskListWithTasksFactory factory,
		                             ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}

		public IEnumerable<ITaskListWithTasks> Read(int userId)
		{
			IEnumerable<KeyValuePair<int, TempQueryResult>> kvpList 
				= _dataProxy.ExecuteOnCollection(_factory, ReadStoredProcedure);

			var listNameCache = new Dictionary<int, string>();
			var taskCache = new Dictionary<int, List<ITask>>();

			var retVal = new List<ITaskListWithTasks>();

			foreach (var item in kvpList)
			{
				int listId = item.Key;
				string listName = item.Value.ListName;
				ITask task = item.Value.Task;

				if (!listNameCache.ContainsKey(listId))
				{
					listNameCache[listId] = listName;
				}

				if (!taskCache.ContainsKey(listId))
				{
					taskCache[listId] = new List<ITask>();
				}
				taskCache[listId].Add(task);
			}

			foreach (var kvp in listNameCache)
			{
				int listId = kvp.Key;
				string value = kvp.Value;

				// TODO does this still work if a list has no tasks?
				List<ITask> tasks = taskCache[listId];

				var taskListWithTasks = new TaskListWithTasks(listId, value, tasks);
			}

			return retVal;
		}
	}
}