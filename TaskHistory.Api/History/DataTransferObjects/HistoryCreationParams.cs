using System;

namespace TaskHistory.Api.History.DataTransferObjects
{
	public class HistoryCreationParams
	{
		public BusinessAction Action { get; }
		public DateTime ActionDate { get; }
		public BusinessObject Object { get; }

		public HistoryCreationParams(BusinessAction action,
		                             DateTime actionDate,
		                             BusinessObject obj)
		{
			Action = action;
			ActionDate = actionDate;
			Object = obj;
		}
	}
}
