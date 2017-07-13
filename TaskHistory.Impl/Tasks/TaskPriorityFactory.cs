using System;
using TaskHistory.Api.Sql;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Tasks
{
	public class TaskPriorityFactory : IFromDataReaderFactory<ITaskPriority>
	{
		public ITaskPriority Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));

			int id = reader.GetInt("Id");
			int userId = reader.GetInt("UserId");
			string name = reader.GetString("Name");
			int rank = reader.GetInt("Rank");

			var taskPriority = new TaskPriority(id, userId, name, rank);

			return taskPriority;
		}
	}
}
