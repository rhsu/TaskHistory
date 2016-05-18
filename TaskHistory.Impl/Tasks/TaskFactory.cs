using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace TaskHistory.Impl.Tasks
{
	public class TaskFactory
	{
		public TaskFactory ()
		{
		}

		public ITask CreateTask(MySqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");
			
			int taskId = Convert.ToInt32 (reader ["TaskId"]);
			string content = reader ["Content"].ToString ();
			bool isCompleted = Convert.ToBoolean (reader ["IsCompleted"]);

			return new Task (taskId, content, isCompleted);
		}
	}
}