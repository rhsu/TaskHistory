using System;
using System.Collections.Generic;

namespace TaskHistory.Api.History
{
	public interface IHistoryRepo
	{
		/// <summary>
		/// Gets all the history for a user
		/// </summary>
		/// <param name="userId">User identifier.</param>
		IEnumerable<IHistoryDisplayItem> ReadHistoryForUser(int userId);

		/// <summary>
		/// Records history in the database
		/// </summary>
		/// <param name="historyDto">the history to record</param>
		void CreateHistory (IHistoryDBDto historyDto);

		/// <summary>
		/// Edits history in the database
		/// </summary>
		/// <param name="historyDto">Some dto.</param>
		void UpdateHistory (IHistoryDBDto historyDto);

		/// <summary>
		/// Deletes the specific history item
		/// </summary>
		/// <param name="historyId">The id of the history to delete</param>
		void DeleteHistory (int historyId);
	}
}