using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TaskHistoryApi.Tasks;
using TaskHistoryApi.Users;
using TaskHistoryImpl.MySql;
using TaskHistoryImpl.Tasks;

namespace TaskHistoryImpl.Tasks
{
	public class TaskRepo : ITaskRepo
	{
		private readonly TaskFactory _taskFactory;
		private readonly MySqlCommandFactory _mySqlCommandFactory;

		public ITask InsertNewTask (string taskContent)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Tasks_Insert");
			command.Parameters.Add (new MySqlParameter ("pTaskContent", taskContent));
			command.Connection.Open ();

			MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);
			ITask task = null;

			if (reader.Read ()) 
			{
				task = CreateTaskFromReader (reader);
			}
			command.Connection.Close ();

			return task;
		}
			
		public void DeleteTask (int taskId)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Tasks_LogicalDelete");
			command.Parameters.Add (new MySqlParameter ("pTaskId", taskId));
			command.Connection.Open ();
			command.ExecuteNonQuery ();
			command.Connection.Close ();
		}

		public void UpdateTask (ITask newTaskDto)
		{
			if (newTaskDto == null)
				throw new ArgumentNullException ("newTaskDto");

			var command = _mySqlCommandFactory.CreateMySqlCommand ("Tasks_Update");
			command.Parameters.Add (new MySqlParameter ("pContent", newTaskDto.Content));
			command.Parameters.Add (new MySqlParameter ("pIsCompleted", newTaskDto.IsCompleted));
			command.Parameters.Add (new MySqlParameter ("pTaskID", newTaskDto.TaskId));
			command.Connection.Open ();
			command.ExecuteNonQuery ();
			command.Connection.Close ();
		}

		public IEnumerable<ITask> GetTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var command = _mySqlCommandFactory.CreateMySqlCommand ("Tasks_Select");
			command.Parameters.Add (new MySqlParameter ("pUserId", user.UserId));
			command.Connection.Open ();

			MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

			List<ITask> returnVal = new List<ITask> ();

			while (reader.Read ()) 
			{
				ITask task = CreateTaskFromReader (reader);
				returnVal.Add (task);
			}

			command.Connection.Close ();

			return returnVal;
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

		public TaskRepo (TaskFactory taskFactory, MySqlCommandFactory commandFactory)
		{
			_taskFactory = taskFactory;
			_mySqlCommandFactory = commandFactory;
		}
	}
}

