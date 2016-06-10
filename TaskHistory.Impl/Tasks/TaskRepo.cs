using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Tasks;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Tasks
{
	public class TaskRepo : ITaskRepo
	{
		private const string CreateStoredProcedure = "Tasks_Insert";
		private const string ReadStoredProcedure = "Tasks_Select";
		private const string UpdateStoredProcedure = "Tasks_Update";
		private const string DeleteStoredProcedure = "Tasks_Delete";

		private const string NullFromApplicationDataProxy = "Null returned from DataProvider";

		private readonly TaskFactory _taskFactory;

		private readonly ApplicationDataProxy _applicationDataProxy;

		public ITask CreateNewTask (string taskContent)
		{
			ISqlDataParameter parameter = _applicationDataProxy.ParamFactory.CreateParameter ("pTaskContent", taskContent);

			var returnVal = _applicationDataProxy
				.DataReaderProvider
				.ExecuteReaderForSingleType<ITask> (_taskFactory, CreateStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			return returnVal;
		}

		public IEnumerable<ITask> ReadTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var parameter = _applicationDataProxy.ParamFactory.CreateParameter("pUserId", user.UserId);

			var returnVal = _applicationDataProxy.DataReaderProvider.ExecuteReaderForTypeCollection<ITask> (_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			return returnVal;
		}
			
		public void UpdateTask (TaskUpdatingParameters taskParameterDto)
		{
			if (taskParameterDto == null)
				throw new ArgumentNullException ("taskParameterDto");

			var parameters = new List<ISqlDataParameter> ();
			var paramFactory = _applicationDataProxy.ParamFactory;

			parameters.Add (paramFactory.CreateParameter ("pContent", taskParameterDto.Content));
			parameters.Add (paramFactory.CreateParameter ("pIsCompleted", taskParameterDto.IsCompleted));
			parameters.Add (paramFactory.CreateParameter ("pIsDeleted", taskParameterDto.IsDeleted));
			parameters.Add (paramFactory.CreateParameter ("pTaskId", taskParameterDto.TaskId));

			_applicationDataProxy.NonQueryDataProvider.ExecuteNonQuery (UpdateStoredProcedure, parameters);
		}

		public void DeleteTask (int taskId)
		{
			var parameter = _applicationDataProxy.ParamFactory.CreateParameter ("pTaskId", taskId);

			_applicationDataProxy.NonQueryDataProvider.ExecuteNonQuery (DeleteStoredProcedure, parameter);
		}

		public TaskRepo (TaskFactory taskFactory, 
			ApplicationDataProxy applicationDataProxy)
		{
			_taskFactory = taskFactory;
			_applicationDataProxy = applicationDataProxy;
		}
	}
}