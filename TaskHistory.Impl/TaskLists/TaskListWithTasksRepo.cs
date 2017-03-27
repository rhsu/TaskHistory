using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaskHistory.Api.TaskLists;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListWithTasksRepo : ITaskListWithTasksRepo
	{
		TaskListWithTasksFactory _factory;
		ApplicationDataProxy _dataProxy;

		const string ReadStoredProcedure = "TaskListsWithTasks_Read";

		public TaskListWithTasksRepo(TaskListWithTasksFactory factory,
		                             ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}

		public IEnumerable<ITaskListWithTasks> Read(int userId)
		{
			//TODO temporarily here as a Proof of Concept
			var tempFactory = new TempFactory(null);

			IEnumerable<KeyValuePair<int, TempQueryResult>> kvpList 
				= _dataProxy.ExecuteOnCollection(tempFactory, ReadStoredProcedure);

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

		// TODO Spec changed. Need a Read all but do I still need a Read single?
		/*public ITaskListWithTasks Read(int userId, int listId)
		{
			var task = _dataProxy.ExecuteReader(_factory, ReadStoredProcedure);
			if (task == null)
				throw new NullReferenceException("Null returned from data reader");

			return task;
		}*/
	}
}