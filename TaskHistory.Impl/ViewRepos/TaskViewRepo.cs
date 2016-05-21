using System;
using TaskHistory.Impl.Tasks;
using System.Collections.Generic;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using TaskHistory.Api.ViewRepos;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.ViewRepos
{
	// TODO: Create a TaskView object
	public class TaskViewRepo
	{
		private const string ReadStoredProcedure = "Tasks_Select";

		private readonly TaskFactory _taskFactory;
		private readonly SqlParameterFactory _paramFactory;
		private readonly IDataLayer _dataLayer;
		private readonly SqlDataReaderFactory _dataReaderFactory;

		public TaskViewRepo (TaskFactory taskFactory,
			SqlParameterFactory paramFactory,
			IDataLayer dataLayer,
			SqlDataReaderFactory dataReaderFactory)
		{
			_taskFactory = taskFactory;
			_paramFactory = paramFactory;
			_dataLayer = dataLayer;
			_dataReaderFactory = dataReaderFactory;
		}

		public IEnumerable<ITask> ReadTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			/*using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
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
			}*/
			return null;
		}
	}
}

