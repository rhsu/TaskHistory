using System;
using TaskHistory.Impl.Tasks;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using TaskHistory.Api.ViewRepos;

namespace TaskHistory.Impl.ViewRepos
{
	public class TaskViewRepo : ITaskViewRepo
	{
		private const string ReadStoredProcedure = "Tasks_Select";
		private TaskFactory _taskFactory;

		public TaskViewRepo (TaskFactory taskFactory)
		{
			_taskFactory = taskFactory;
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
	}
}

