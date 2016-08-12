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
		private readonly ApplicationDataProxy _dataProxy;

		public ITask CreateNewTaskForUser (IUser user, string taskContent)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			if (taskContent == null)
				throw new ArgumentNullException ("taskContent");

			var parameters = new List<ISqlDataParameter> ();
			var paramFactory = _dataProxy.ParamFactory;

			parameters.Add (paramFactory.CreateParameter ("pTaskContent", taskContent));
			parameters.Add (paramFactory.CreateParameter ("pUserId", user.UserId));

			var returnVal = _dataProxy
				.DataReaderProvider
				.ExecuteReaderForSingleType<ITask> (_taskFactory, CreateStoredProcedure, parameters);
			if (returnVal == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			return returnVal;
		}

		public IEnumerable<ITask> ReadTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var parameter = _dataProxy.ParamFactory.CreateParameter("pUserId", user.UserId);

			var returnVal = _dataProxy.DataReaderProvider.ExecuteReaderForTypeCollection<ITask> (_taskFactory, ReadStoredProcedure, parameter);
			if (returnVal == null)
				throw new NullReferenceException (NullFromApplicationDataProxy);

			return returnVal;
		}
			
		public void UpdateTask (TaskUpdatingParameters taskParameterDto)
		{
			if (taskParameterDto == null)
				throw new ArgumentNullException ("taskParameterDto");

			var parameters = new List<ISqlDataParameter> ();
			var paramFactory = _dataProxy.ParamFactory;

			parameters.Add (paramFactory.CreateParameter ("pContent", taskParameterDto.Content));
			parameters.Add (paramFactory.CreateParameter ("pIsCompleted", taskParameterDto.IsCompleted));
			parameters.Add (paramFactory.CreateParameter ("pIsDeleted", taskParameterDto.IsDeleted));
			parameters.Add (paramFactory.CreateParameter ("pTaskId", taskParameterDto.TaskId));

			_dataProxy.NonQueryDataProvider.ExecuteNonQuery (UpdateStoredProcedure, parameters);
		}

		public void DeleteTask (int taskId)
		{
			var parameter = _dataProxy.ParamFactory.CreateParameter ("pTaskId", taskId);

			_dataProxy.NonQueryDataProvider.ExecuteNonQuery (DeleteStoredProcedure, parameter);
		}

		public IEnumerable<ITask> ReadAllTasks(int limit)
		{
			var returnVal = new List<ITask> ();

			for (var i = 0; i < 3; i++) 
			{
				returnVal.Add(new Task(i, string.Format("content {0}", i), false));
			}

			return returnVal;
		}

		public TaskRepo (TaskFactory taskFactory, 
			ApplicationDataProxy applicationDataProxy)
		{
			_taskFactory = taskFactory;
			_dataProxy = applicationDataProxy;
		}
	}
}