namespace TaskHistory.Api.History.DataTransferObjects
{
	public class HistoryCreationParams
	{
		public BusinessAction Action { get; }
		public BusinessObject Object { get; }

		public HistoryCreationParams(BusinessAction action,
									 BusinessObject obj)
		{
			Action = action;
			Object = obj;
		}
	}
}
