using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Tasks
{
	public class TaskPriorityRepo : ITaskPriorityRepo
	{
		TaskPriorityFactory _factory;
		ApplicationDataProxy _dataProxy;

		public TaskPriorityRepo(TaskPriorityFactory factory, 
		                        ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}

		public ITaskPriority Create(int userId, string name)
		{
			// TODO should rank belong somewhere else?
			//		don't need it yet until the admin page

			// TODO null check of name

			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));			
			parameters.Add(_dataProxy.CreateParameter("pUserId", name));


			throw new NotImplementedException();
		}

		public ITaskPriority Delete()
		{
			throw new NotImplementedException();
		}

		public ITaskPriority Read()
		{
			throw new NotImplementedException();
		}

		public ITaskPriority Update()
		{
			throw new NotImplementedException();
		}
	}
}
