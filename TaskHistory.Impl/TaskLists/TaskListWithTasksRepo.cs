using System.Collections.Generic;
using TaskHistory.Api.Sql;
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

		const string ReadAllStoredProcedure = "TaskListsWithTasks_Select";

		public TaskListWithTasksRepo(TaskListWithTasksFactory factory,
		                             ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}

		public IEnumerable<ITaskListWithTasks> ReadAll(int userId)
		{
			var parameter = _dataProxy.CreateParameter("pUserId", userId);

			IEnumerable<KeyValuePair<int, TaskListWithTasksQueryResult>> kvpList 
				= _dataProxy.ExecuteOnCollection(_factory, 
			                                     ReadAllStoredProcedure,
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

		public ITaskListWithTasks Read(int userId, int listId)
		{
			var parameter = new List<ISqlDataParameter>();
			parameter.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameter.Add(_dataProxy.CreateParameter("pListId", listId));

			// TODO I believe this returns a List
			var kvp = _dataProxy.ExecuteReader(_factory, "");

			// storage where key is the listId and vaue is the listName
			var listNameCache = new Dictionary<int, string>();

			// storage where key is the listId and value is the list of tasks
			var taskCache = new Dictionary<int, List<ITask>>();

			var retVal = new List<ITaskListWithTasks>();

			// TODO can't continue until I know what the shape of the stored procedure returns

			return null;
		}
	}
}