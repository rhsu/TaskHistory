using System;
using TaskHistoryApi.Tasks;
using System.Collections.Generic;
using TaskHistoryImpl.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TaskHistoryImpl.TaskRepo
{
	public class TaskRepo : ITaskRepo
	{
		private readonly TaskFactory _taskFactory;
		private readonly MySqlCommandFactory _mySqlCommandFactory;

		public void CreateTask (ITask task)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Task_Insert");
			command.Parameters.Add (new MySqlParameter ("pTaskContent", task.Content));
			command.Parameters.Add (new MySqlParameter ("pUserId", 0));
			command.Connection.Open ();
			command.ExecuteNonQuery ();
			command.Connection.Close ();
		}

		public void DeleteTask (int taskId)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Task_LogicalDelete");
			command.Parameters.Add (new MySqlParameter ("pTaskId", taskId));
			command.Connection.Open ();
			command.ExecuteNonQuery ();
			command.Connection.Close ();
		}

		public void UpdateTask (int taskId, ITask newTaskDto)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Tasks_Update");
			command.Parameters.Add (new MySqlParameter ("pContent", newTaskDto.Content));
			command.Parameters.Add (new MySqlParameter ("pIsCompleted", newTaskDto.IsCompleted));
			command.Parameters.Add (new MySqlParameter ("pTaskID", newTaskDto.TaskId));
			command.Connection.Open ();
			command.ExecuteNonQuery ();
			command.Connection.Close ();
		}

		public IEnumerable<ITask> GetTasksByUserId (int userId)
		{
			var command = _mySqlCommandFactory.CreateMySqlCommand ("Tasks_Select");
			command.Parameters.Add (new MySqlParameter ("pUserId", userId));
			command.Connection.Open ();

			MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

			List<ITask> returnVal = new List<ITask> ();

			while (reader.Read ()) 
			{
				int taskId = Convert.ToInt32 (reader ["TaskId"]);
				string content = reader ["Content"].ToString ();
				bool isCompleted = Convert.ToBoolean (reader ["IsCompleted"]);

				ITask task = _taskFactory.CreateTask (taskId, content, isCompleted);
				returnVal.Add (task);
			}

			return returnVal;
		}

		public TaskRepo (TaskFactory taskFactory, MySqlCommandFactory commandFactory)
		{
			_taskFactory = taskFactory;
			_mySqlCommandFactory = commandFactory;
		}
	}
}

