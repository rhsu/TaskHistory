using System;
using TaskHistory.Api.History;
using System.Collections.Generic;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.History
{
	public class HistoryRepo : IHistoryRepo
	{
		private IApplicationDataProxy _dataProxy;
		private IFromDataReaderFactory<IHistoryItem> _historyItemFactory;

		/// <summary>
		/// Gets all the history for a user
		/// </summary>
		/// <param name="userId">User identifier.</param>
		public IEnumerable<IHistoryItem> ReadHistoryForUser(int userId)
		{
			var parameters = new List<ISqlDataParameter> ();
			var paramFactory = _dataProxy.ParamFactory;

			parameters.Add (paramFactory.CreateParameter ("pUserId", userId));


			throw new NotImplementedException ("Not implemented");
		}

		/// <summary>
		/// Records history in the database
		/// </summary>
		/// <param name="history">the history to record</param>
		public void CreateHistory (IHistoryItem history)
		{
			throw new NotImplementedException ("Not implemented");
		}

		/// <summary>
		/// Edits history in the database
		/// </summary>
		/// <param name="someDto">Some dto.</param>
		public void UpdateHistory (object someDto)
		{
			throw new NotImplementedException ("Not implemented");
		}

		/// <summary>
		/// Deletes the specific history item
		/// </summary>
		/// <param name="historyId">The id of the history to delete</param>
		public void DeleteHistory (int historyId)
		{
			throw new NotImplementedException ("Not implemented");
		}

		public HistoryRepo (IApplicationDataProxy dataProxy, IFromDataReaderFactory<IHistoryItem> historyItemFactory)
		{
			_dataProxy = dataProxy;
			_historyItemFactory = historyItemFactory;
		}
	}
}

