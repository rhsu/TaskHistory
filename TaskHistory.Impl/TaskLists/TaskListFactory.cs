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
			throw new NotImplementedException();
		}
	}
}
