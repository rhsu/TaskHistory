using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;
using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Shared;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Tasks
{
	public class TaskPriorityRepo : BaseRepo, ITaskPriorityRepo
	{
		TaskPriorityFactory _factory;

		const string CreateStoredProcedure = "TaskPriority_Insert";
		const string ReadStoredProcedure = "TaskPriority_Read";
		const string UpdateStoredProcedure = "TaskPriority_Update";
		const string DeleteStoredProcedure = "TaskPriority_Delete";

		public TaskPriorityRepo(TaskPriorityFactory factory,
								ApplicationDataProxy dataProxy)
			: base(dataProxy)
		{
			_factory = factory;
		}

		public ITaskPriority Create(int userId, string name, int rank)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			// TODO should rank belong somewhere else?
			//		don't need it yet until the admin page

			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));			
			parameters.Add(_dataProxy.CreateParameter("pUserId", name));
			parameters.Add(_dataProxy.CreateParameter("pRank", rank));

			var taskPriority = _dataProxy.ExecuteReader(
				_factory,
				CreateStoredProcedure);

			if (taskPriority == null)
				throw new NullReferenceException();

			return taskPriority;
		}

		public int Delete(int userId, int id)
		{
			var parameters = new List<ISqlDataParameter>();
			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pUserId", id));

			return _dataProxy.ExecuteNonQuery(DeleteStoredProcedure, parameters);
		}

		public IEnumerable<ITaskPriority> Read(int userId)
		{
			throw new NotImplementedException();
		}

		public ITaskPriority Update()
		{
			throw new NotImplementedException();
		}
	}
}
