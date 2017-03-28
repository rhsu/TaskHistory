using System;

namespace TaskHistory.Api.History
{
	public interface IHistory
	{
		int Id { get; }
		int UserId { get; }
		BusinessAction Action { get; }
		BusinessObject Object { get; }
		DateTime ActionDate { get; }
	}
}
