using System;

namespace TaskHistory.Api.History
{
	public interface IHistoryDBDto
	{
		int HistoryId { get; }
		DateTime ActionDate { get; }
		ActionType ActionDone { get; }
		BusinessObjectType BusinessObject { get; }
		int UserId { get; }
	}
}