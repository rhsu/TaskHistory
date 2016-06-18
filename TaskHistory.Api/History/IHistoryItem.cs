using System;

namespace TaskHistory.Api.History
{
	/// <summary>
	/// Displays the History that a user performed.
	/// On Date, userId created, read or accessed, updated, deleted some businessobject
	/// </summary>
	public interface IHistoryItem
	{
		int HistoryId { get; }
		DateTime ActionDate { get; }
		ActionType ActionDone { get; }
		BusinessObjectType BusinessObject { get; }
		int UserId { get; }
		string UserName { get; }
	}
}