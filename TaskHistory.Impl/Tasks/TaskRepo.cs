using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.MySql;
using TaskHistory.Impl.Tasks;
using System.Configuration;
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
		private readonly SqlDataReaderFactory _dataReaderFactory;
		private readonly SqlParameterFactory _paramFactory;

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

		public void UpdateTask (ITask newTaskDto)
		{
			if (newTaskDto == null)
				throw new ArgumentNullException ("newTaskDto");

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (UpdateStoredProcedure, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pContent", newTaskDto.Content));
				command.Parameters.Add (new MySqlParameter ("pIsCompleted", newTaskDto.IsCompleted));
				// TODO: https://github.com/rhsu/TaskHistory/issues/51
				command.Parameters.Add (new MySqlParameter ("pTaskID", newTaskDto.TaskId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
			}
		}

		public void DeleteTask (int taskId)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (DeleteStoredProcedure)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pTaskId", taskId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
			}
		}

		public TaskRepo (TaskFactory taskFactory, 
			SqlParameterFactory paramFactory,
			IDataLayer dataLayer, 
			SqlDataReaderFactory dataReaderFactory)
		{
			_taskFactory = taskFactory;
			_paramFactory = paramFactory;
			_dataLayer = dataLayer;
			_dataReaderFactory = dataReaderFactory;
		}
	}
}