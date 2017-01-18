using System;
using TaskHistory.Api.Sql;
using TaskHistory.Api.TaskLists;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.TaskLists
{
	public class TaskListFactory : BaseFromDataReaderFactory<ITaskList>
	{
		public override ITaskList Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));

			int id = reader.GetInt("Id");
			string name = reader.GetString("Name");

			return new TaskList(id, name);
		}
	}
}
