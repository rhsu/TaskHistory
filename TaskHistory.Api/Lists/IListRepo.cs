using System.Collections.Generic;

namespace TaskHistory.Api
{
	public interface IListRepo
	{
		IEnumerable<IList> ReadLists(int userId);

		bool UpdateList(int userId, int listId);
	}
}