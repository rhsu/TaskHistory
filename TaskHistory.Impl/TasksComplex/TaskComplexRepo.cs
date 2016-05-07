using System;
using TaskHistory.Api.TasksComplex;
using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Impl.MySql;
using MySql.Data.MySqlClient;
using System.Data;
using TaskHistory.Api.Labels;
using System.Configuration;

namespace TaskHistory.Impl.TasksComplex
{
	public class TaskComplexRepo : ITaskComplexRepo
	{
		private readonly TaskComplexFactory _taskComplexFactory;

		public IEnumerable<ITaskComplex> GetComplexTasksForUser (IUser user)
		{
			if (user == null)
				throw new ArgumentNullException ("user");

			var returnVal = new List<ITaskComplex> ();

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand ("Labels_Get", connection)) 
			{
				command.Parameters.Add (new MySqlParameter ("pUserId", user.UserId));
				command.Connection.Open ();
				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);

				while (reader.Read ()) 
				{
					ITaskComplex task = CreateTaskComplexFromReader (reader);
					returnVal.Add (task);
				}
			}
				
			return returnVal;
		}

		private ITaskComplex CreateTaskComplexFromReader(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			int taskId = Convert.ToInt32 (reader ["TaskId"]);
			string content = reader ["Content"].ToString ();
			bool isCompleted = Convert.ToBoolean (reader ["IsCompleted"]);

			// TODO: https://github.com/rhsu/TaskHistoryApi/issues/13
			var labels = new List<ILabel> ();

			var returnVal = _taskComplexFactory.CreateTaskComplex (taskId, content, isCompleted, labels);

			return returnVal;
		}

		public TaskComplexRepo (TaskComplexFactory taskComplexFactory)
		{
			_taskComplexFactory = taskComplexFactory;
		}
	}
}