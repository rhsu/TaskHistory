using System;
using System.Collections.Generic;
using System.Linq;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Sql;
using TaskHistory.Impl.TaskLists.QueryResults;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListRepo : ITaskListRepo
	{
		TaskListWithTasksFactory _factory;
		ApplicationDataProxy _dataProxy;

		const string CreatedStoredProcedure = "TaskLists_Create";

		const string ReadAllStoredProcedure = "TaskLists_All_Select";
		const string ReadStoredProcedure = "TaskLists_Select";

		public TaskListRepo(TaskListWithTasksFactory factory,
		                             ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}

		public IEnumerable<ITaskList> ReadAll(int userId)
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

			var retVal = new List<ITaskList>();

			foreach (var item in kvpList)
			{
				// there is an assumption that a list cannot exist without a name
				// but a list could contain 0 tasks
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

				// TODO this should be done via a new TaskListFactory
				List<ITask> tasks = taskCache[listId];

				var taskListWithTasks = new TaskList(listId, listName, tasks);

				retVal.Add(taskListWithTasks);
			}

			return retVal;
		}

		public ITaskList Read(int userId, int listId)
		{
			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pListId", listId));

			var kvpList = _dataProxy.ExecuteOnCollection(_factory, 
			                                             ReadStoredProcedure,
			                                             parameters);
			if (kvpList == null)
				throw new NullReferenceException("null returned from DataProxy");

			var tasks = new List<ITask>();

			string listName = kvpList.First().Value.ListName;

			foreach (var item in kvpList)
			{
				ITask task = item.Value.Task;

				if (task != null)
				{
					tasks.Add(task);
				}
			}

			var retVal = new TaskList(listId, listName, tasks);

			return retVal;
		}

		public ITaskList Create(int userId, string listContent)
		{
			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pName", listContent));

			var kvpList = _dataProxy.ExecuteOnCollection(_factory,
														 CreatedStoredProcedure,
														 parameters);
			if (kvpList == null)
				throw new NullReferenceException("null returned from DataProxy");

			string listName = kvpList.First().Value.ListName;
			int listId = kvpList.First().Key;

			var retVal = new TaskList(listId, listName, new List<ITask>());
			return retVal;
		}
	}
}