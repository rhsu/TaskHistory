using System.Collections.Generic;
using TaskHistory.Api.Lists;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Lists
{
	public class TaskListsRepo : ITaskListsRepo
	{
		public IEnumerable<ITaskLists> ReadLists(int userId)
		{
			return null;
		}



		public TaskListsRepo(ListFactory listFactory,
		               ApplicationDataProxy appDataProxy)
		{
		}
	}
}
