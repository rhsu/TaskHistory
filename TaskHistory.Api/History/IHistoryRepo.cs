using System.Collections.Generic;
using TaskHistory.Api.History.DataTransferObjects;

namespace TaskHistory.Api.History
{
	public interface IHistoryRepo
	{
		IEnumerable<IHistory> Get(int userId);

		IHistory Record(HistoryCreationParams historyDto);
	}
}