using System;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListWithTasksFactory : IFromDataReaderFactory<ITaskListWithTasks>
	{
		public ITaskListWithTasks Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new NullReferenceException(nameof(reader));

			int id = reader.GetInt("Id");
			string name = reader.GetString("Name");

			throw new NotImplementedException();
		}
	}
}
