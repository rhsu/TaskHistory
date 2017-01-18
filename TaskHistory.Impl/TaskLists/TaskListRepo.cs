using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListRepo : ITaskListRepo
	{
		const string CreateStoredProcedure = "TaskLists_Create";
		const string ReadStoredProcedure = "TaskLists_Read";
		const string UpdatedStoredProceudre = "TaskLists_Update";

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
			var pUserId = _appDataProxy.CreateParameter("pUserId", userId);

			var tasksLists = _appDataProxy.ExecuteOnCollection(_factory,
																		  ReadStoredProcedure,
																		  pUserId);

			if (tasksLists == null)
				throw new NullReferenceException("null returned from appDataProxy");

			return tasksLists;
		}

		public ITaskList Update(int userId, int listId, string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_appDataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_appDataProxy.CreateParameter("pListId", userId));			
			parameters.Add(_appDataProxy.CreateParameter("pName", userId));

			var retVal = _appDataProxy.Execute(_factory,
								  UpdatedStoredProceudre,
								  parameters);

			if (retVal == null)
				throw new NullReferenceException("Null returned from appDataProxy");

			return retVal;
		}

		public TaskListRepo(TaskListFactory taskListFactory, ApplicationDataProxy appDataProxy)
		{
			_factory = taskListFactory;
			_appDataProxy = appDataProxy;
		}
	}
}
