using System.Collections.Generic;

namespace TaskHistory
{
	public class TerminalResponseObject
	{
		public IEnumerable<string> ResponseSummary { get; }

		public TerminalResponseObject(IEnumerable<string> responseSummary)
		{
			ResponseSummary = responseSummary;
		}
	}
}