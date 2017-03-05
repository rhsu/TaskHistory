using System;

namespace TaskHistory.Api.History
{
	/// <summary>
	/// Displays the History that a user performed.
	/// On Date, username created, read or accessed, updated, deleted some businessobject
	/// </summary>
	public interface IHistoryDisplayItem
	{
		int HistoryId { get; }
		DateTime ActionDate { get; }
		ActionType ActionDone { get; }
		BusinessObjectType BusinessObject { get; }
		string UserName { get; }
	}
}