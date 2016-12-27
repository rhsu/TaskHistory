using System.Collections.Generic;

namespace TaskHistory.Api.Lists
{
	public interface IListRepo
	{
		IEnumerable<IList> ReadLists(int userId);

		IList UpdateList(int userId, int listId);
	}
}