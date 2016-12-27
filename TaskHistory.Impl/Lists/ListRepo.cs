using System.Collections.Generic;
using TaskHistory.Api.Lists;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Lists
{
	public class ListRepo : IListRepo
	{
		public IEnumerable<IList> ReadLists(int userId)
		{
			return null;
		}

		public IList UpdateList(int userId, int listId)
		{
			return null;
		}

		public ListRepo(ListFactory listFactory,
		               ApplicationDataProxy appDataProxy)
		{
		}
	}
}
