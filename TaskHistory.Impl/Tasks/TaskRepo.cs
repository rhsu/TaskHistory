using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Impl.MySql;
using TaskHistory.Impl.Tasks;
using System.Configuration;

namespace TaskHistory.Impl.Tasks
{
	public class TaskRepo : ITaskRepo
	{
		private const string CreateStoredProcedure = "Tasks_Insert";
		private const string ReadStoredProcedure = "Tasks_Select";
		private const string UpdateStoredProcedure = "Tasks_Update";
		private const string DeleteStoredProcedure = "Tasks_Delete";

		private readonly TaskFactory _taskFactory;

		public ITask CreateNewTask (string taskContent)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (CreateStoredProcedure, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pTaskContent", taskContent));
				command.Connection.Open ();

				using (var reader = command.ExecuteReader (CommandBehavior.CloseConnection)) 
				{
					ITask task = null;

					if (reader.Read ()) 
					{
						task = _taskFactory.CreateTask (reader);
					}

					return task;
				}
			}
		}

		public IEnumerable<ITask> ReadTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand(ReadStoredProcedure, connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add (new MySqlParameter ("pUserId", user.UserId));
				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

				List<ITask> returnVal = new List<ITask> ();

				while (reader.Read ()) 
				{
					ITask task = _taskFactory.CreateTask (reader);
					returnVal.Add (task);
				}

				return returnVal;
			}
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

		public TaskRepo (TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
		}
	}
}

