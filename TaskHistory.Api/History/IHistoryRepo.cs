using System.Collections.Generic;
using TaskHistory.Api.History.DataTransferObjects;

namespace TaskHistory.Api.History
{
	public interface IHistoryRepo
	{
		IEnumerable<IHistory> Read(int userId);

		IHistory Create(int userId, HistoryCreationParams historyDto);
	}
}