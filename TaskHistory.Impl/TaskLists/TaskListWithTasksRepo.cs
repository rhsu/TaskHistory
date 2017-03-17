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

		public ITaskListWithTasks Read(int userId)
		{
			var list = _dataProxy.ExecuteReader(_factory, ReadStoredProcedure);
			if (list == null)
				throw new NullReferenceException("Null returned from data proxy");

			//TODO temporarily here as a Proof of Concept
			var tempFactory = new TempFactory(null);

			IEnumerable<KeyValuePair<int, ITask>> things = _dataProxy.ExecuteOnCollection(tempFactory, "");

			var cachedResultSet = new Dictionary<int, ITask>();

			/*for (var i = 0; i < things.Count(); i++)
			{
				// TODO I forogt how to iterate through IEnumerable
				var currentThing = things.ElementAt(i);

				if (cachedResultSet.ContainsKey(currentThing.Key))
				{
				}
				else
				{
				}
			}*/

			// TODO and then loop again to unflatten the array

			return list;
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