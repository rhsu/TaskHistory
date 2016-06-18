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
		IEnumerable<IHistoryItem> ReadHistoryForUser(int userId);

		/// <summary>
		/// Records history in the database
		/// </summary>
		/// <param name="history">the history to record</param>
		void CreateHistory (IHistoryItem history);

		/// <summary>
		/// Edits history in the database
		/// </summary>
		/// <param name="someDto">Some dto.</param>
		void UpdateHistory (object someDto);

		/// <summary>
		/// Deletes the specific history item
		/// </summary>
		/// <param name="historyId">The id of the history to delete</param>
		void DeleteHistory (int historyId);
	}
}