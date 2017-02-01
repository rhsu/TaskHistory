namespace TaskHistory.WebApp
{
	public class TerminalResponseObject
	{
		public string ResponseSummary { get; }

		public TerminalResponseObject(string responseSummary)
		{
			this.ResponseSummary = responseSummary;
		}
	}
}