using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListRepo : ITaskListRepo
	{
		const string CreateStoredProcedure = "TaskList_Create";

		TaskListFactory _factory;
		ApplicationDataProxy _appDataProxy;

		public bool AssociateTasksToList(int userId, int listId, IEnumerable<int> taskIds)
		{
			throw new NotImplementedException();
		}

		public ITaskList Create(int userId, string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_appDataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_appDataProxy.CreateParameter("pName", name));

			var newTaskList = _appDataProxy.Execute(_factory,
													CreateStoredProcedure,
													parameters);

			return newTaskList;
		}

		public IEnumerable<ITaskList> Read(int userId)
		{
			throw new NotImplementedException();
		}

		public ITaskList Update(int userId, string name)
		{
			throw new NotImplementedException();
		}

		public TaskListRepo(TaskListFactory taskListFactory, ApplicationDataProxy appDataProxy)
		{
			_factory = taskListFactory;
			_appDataProxy = appDataProxy;
		}
	}
}
