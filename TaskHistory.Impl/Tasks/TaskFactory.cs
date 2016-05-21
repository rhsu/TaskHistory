using TaskHistory.Api.Tasks;
using TaskHistory.Impl.Tasks;
using MySql.Data.MySqlClient;
using System;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Tasks
{
	public class TaskFactory : AbstractFromDataReaderFactory<ITask>
	{
		public TaskFactory (SqlDataReaderFactory dataReaderFactory)
			: base (dataReaderFactory)
		{
		}

		public override ITask CreateTypeFromDataReader(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");
			
			int taskId = reader.GetInt ("TaskId");
			string content = reader.GetString ("Content");
			bool isCompleted = reader.GetBool ("IsCompleted");

			return new Task (taskId, content, isCompleted);
		}
	}
}