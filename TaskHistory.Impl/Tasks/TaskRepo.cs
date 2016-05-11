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

		public ITask InsertNewTask (string taskContent)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (CreateStoredProcedure)) 
			{
				command.CommandType = CommandType.StoredProcedure;
				
				command.Parameters.Add (new MySqlParameter ("pTaskContent", taskContent));
				command.Connection.Open ();

				using (var reader = command.ExecuteReader (CommandBehavior.CloseConnection)) 
				{
					ITask task = null;

					if (reader.Read ()) 
					{
						task = CreateTaskFromReader (reader);
					}

					return task;
				}
			}
		}
			
		public void DeleteTask (int taskId)
		{
			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (DeleteStoredProcedure)) 
			{
				command.Parameters.Add (new MySqlParameter ("pTaskId", taskId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
			}

		}

		public void UpdateTask (ITask newTaskDto)
		{
			if (newTaskDto == null)
				throw new ArgumentNullException ("newTaskDto");

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (UpdateStoredProcedure, connection)) 
			{
				command.Parameters.Add (new MySqlParameter ("pContent", newTaskDto.Content));
				command.Parameters.Add (new MySqlParameter ("pIsCompleted", newTaskDto.IsCompleted));
				// TODO: https://github.com/rhsu/TaskHistory/issues/51
				command.Parameters.Add (new MySqlParameter ("pTaskID", newTaskDto.TaskId));
				command.Connection.Open ();
				command.ExecuteNonQuery ();
			}
		}

		public IEnumerable<ITask> GetTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand(ReadStoredProcedure, connection))
			{
				command.Parameters.Add (new MySqlParameter ("pUserId", user.UserId));
				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

				List<ITask> returnVal = new List<ITask> ();

				while (reader.Read ()) 
				{
					ITask task = CreateTaskFromReader (reader);
					returnVal.Add (task);
				}

				return returnVal;
			}

		}

		private ITask CreateTaskFromReader(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			int taskId = Convert.ToInt32 (reader ["TaskId"]);
			string content = reader ["Content"].ToString ();
			bool isCompleted = Convert.ToBoolean (reader ["IsCompleted"]);

			ITask task = _taskFactory.CreateTask (taskId, content, isCompleted);

			return task;
		}

		public TaskRepo (TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
		}
	}
}

