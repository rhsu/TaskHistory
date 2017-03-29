using System.Collections.Generic;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Sql;
using TaskHistory.Impl.TaskLists.QueryResults;

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
			var parameter = _dataProxy.CreateParameter("pUserId", userId);

			IEnumerable<KeyValuePair<int, TaskListWithTasksQueryResult>> kvpList 
				= _dataProxy.ExecuteOnCollection(_factory, 
			                                     ReadStoredProcedure,
			                                     parameter);

			// storage where key is the listId and vaue is the listName
			var listNameCache = new Dictionary<int, string>();

			// storage where key is the listId and value is the list of tasks
			var taskCache = new Dictionary<int, List<ITask>>();

			// there is an assumption that a list cannot exist without a name
			// but a list could contain 0 tasks

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

				if (task != null)
				{
					taskCache[listId].Add(task);
				}
			}

			foreach (var kvp in listNameCache)
			{
				int listId = kvp.Key;
				string listName = kvp.Value;

				List<ITask> tasks = taskCache[listId];

				var taskListWithTasks = new TaskListWithTasks(listId, listName, tasks);

				retVal.Add(taskListWithTasks);
			}

			return retVal;
		}
	}
}