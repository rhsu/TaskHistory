using System;
using TaskHistory.Api.History;
using System.Collections.Generic;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.History
{
	public class HistoryRepo : IHistoryRepo
	{
		private const string CreateStoredProcedure = "History_Create";
		private const string ReadStoredProcedure = "History_Select";
		private const string UpdateStoredProcedure = "History_Update";
		private const string DeleteStoredProcedure = "History_Delete";

		private readonly IApplicationDataProxy _dataProxy;
		private readonly IFromDataReaderFactory<IHistoryDisplayItem> _historyItemFactory;

		/// <summary>
		/// Gets all the history for a user
		/// </summary>
		/// <param name="userId">User identifier.</param>
		public IEnumerable<IHistoryDisplayItem> ReadHistoryForUser(int userId)
		{
			ISqlParameterFactory paramFactory = _dataProxy.ParamFactory;
			ISqlDataParameter parameter = paramFactory.CreateParameter ("pUserId", userId);

			IEnumerable<IHistoryDisplayItem> returnVal = _dataProxy.DataReaderProvider
				.ExecuteReaderForTypeCollection<IHistoryDisplayItem>(_historyItemFactory, 
					ReadStoredProcedure, 
					parameter);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from dataProxy");

			return returnVal;
		}

		/// <summary>
		/// Records history in the database
		/// </summary>
		/// <param name="history">the history to record</param>
		public void CreateHistory (IHistoryDBDto history)
		{
			if (history == null)
				throw new ArgumentNullException ("history");

			ISqlParameterFactory paramFactory = _dataProxy.ParamFactory;

			var parameters = new List<ISqlDataParameter> ();

			var actionDateParam = paramFactory.CreateParameter ("pActionDate", history.ActionDate);
			parameters.Add (actionDateParam);

			var actionDoneParam = paramFactory.CreateParameter ("pActionDone", history.ActionDone);
			parameters.Add (actionDoneParam);

			var businessObjectParam = paramFactory.CreateParameter ("pBusinessObj", history.BusinessObject);
			parameters.Add (businessObjectParam);

			var userIdParam = paramFactory.CreateParameter ("pUserId", history.UserId);
			parameters.Add (userIdParam);

			_dataProxy.NonQueryDataProvider.ExecuteNonQuery (CreateStoredProcedure, parameters);
		}

		/// <summary>
		/// Edits history in the database
		/// </summary>
		/// <param name="history">history to update.</param>
		public void UpdateHistory (IHistoryDBDto history)
		{
			if (history == null)
				throw new ArgumentNullException ("history");

			/*ISqlParameterFactory paramFactory = _dataProxy.ParamFactory;

			var parameters = new List<ISqlDataParameter> ();

			var actionDateParam = paramFactory.CreateParameter ("pActionDate", history.ActionDate);
			parameters.Add (actionDateParam);

			var actionDoneParam = paramFactory.CreateParameter ("pActionDone", history.ActionDone);
			parameters.Add (actionDoneParam);

			var businessObjectParam = paramFactory.CreateParameter ("pBusinessObj", history.BusinessObject);
			parameters.Add (businessObjectParam);

			var userIdParam = paramFactory.CreateParameter ("pUserId", history.UserId);
			parameters.Add (userIdParam);

			_dataProxy.NonQueryDataProvider.ExecuteNonQuery (UpdateStoredProcedure, parameters);*/

			throw new NotImplementedException ("Need to rethink this. When will history ever be modified?");
		}

		/// <summary>
		/// Deletes the specific history item
		/// </summary>
		/// <param name="historyId">The id of the history to delete</param>
		public void DeleteHistory (int historyId)
		{
			ISqlParameterFactory paramFactory = _dataProxy.ParamFactory;
			ISqlDataParameter parameter = paramFactory.CreateParameter ("pHistoryId", historyId);

			_dataProxy.NonQueryDataProvider.ExecuteNonQuery (DeleteStoredProcedure, parameter);
		}

		public HistoryRepo (IApplicationDataProxy dataProxy, IFromDataReaderFactory<IHistoryDisplayItem> historyItemFactory)
		{
			_dataProxy = dataProxy;
			_historyItemFactory = historyItemFactory;
		}
	}
}

