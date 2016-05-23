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

		private readonly TaskFactory _taskFactory;
		private readonly IDataLayer _dataLayer;
		private readonly SqlParameterFactory _paramFactory;
		private readonly INonQueryDataProvider _nonQueryDataProvider;

		public ITask CreateNewTask (string taskContent)
		{
			ISqlDataParameter parameter = _paramFactory.CreateParameter ("pTaskContent", taskContent);

			var returnVal = _dataLayer.ExecuteReaderForSingleType<ITask> (_taskFactory, CreateStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from dataLayer");

			return returnVal;
		}

		public IEnumerable<ITask> ReadTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var parameter = _paramFactory.CreateParameter("pUserId", user.UserId);

			var returnVal = _dataLayer.ExecuteReaderForTypeCollection<ITask> (_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from dataLayer");

			return returnVal;
		}

		// TODO: https://github.com/rhsu/TaskHistory/issues/51
		public void UpdateTask (ITask newTaskDto)
		{
			if (newTaskDto == null)
				throw new ArgumentNullException ("newTaskDto");

			var parameters = new List<ISqlDataParameter> ();

			parameters.Add (_paramFactory.CreateParameter ("pContent", newTaskDto.Content));
			parameters.Add (_paramFactory.CreateParameter ("pIsCompleted", newTaskDto.IsCompleted));
			parameters.Add (_paramFactory.CreateParameter ("pTaskId", newTaskDto.TaskId));

			_nonQueryDataProvider.ExecuteNonQuery (UpdateStoredProcedure, parameters);
		}

		public void DeleteTask (int taskId)
		{
			var parameter = _paramFactory.CreateParameter ("pTaskId", taskId);

			_nonQueryDataProvider.ExecuteNonQuery (DeleteStoredProcedure, parameter);
		}

		public TaskRepo (TaskFactory taskFactory, 
			SqlParameterFactory paramFactory,
			INonQueryDataProvider nonQueryDataProvider,
			IDataLayer dataLayer)
		{
			_taskFactory = taskFactory;
			_paramFactory = paramFactory;
			_dataLayer = dataLayer;
		}
	}
}