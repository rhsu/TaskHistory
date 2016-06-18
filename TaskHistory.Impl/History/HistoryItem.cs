using System;
using TaskHistory.Api.History;

namespace TaskHistory.Impl.History
{
	public class HistoryItem : IHistoryItem
	{
		public int HistoryId { get; }
		public DateTime ActionDate { get; }
		public ActionType ActionDone { get; }
		public BusinessObjectType BusinessObject { get; }
		public int UserId { get; }
		public string UserName { get; }

		public HistoryItem (int historyId,
			DateTime actionDate,
			ActionType actionDone,
			BusinessObjectType businessObjType,
			int userId,
			string userName)
		{
			HistoryId = historyId;
			ActionDate = actionDate;
			ActionDone = actionDone;
			BusinessObject = businessObjType;
			UserId = userId;
			UserName = userName;
		}
	}
}

