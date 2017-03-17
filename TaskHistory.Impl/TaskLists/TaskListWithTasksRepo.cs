using System;
using TaskHistory.Api.TaskLists;
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

		public ITaskListWithTasks Read(int userId)
		{
			var list = _dataProxy.ExecuteReader(_factory, ReadStoredProcedure);
			if (list == null)
				throw new NullReferenceException("Null returned from data proxy");

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