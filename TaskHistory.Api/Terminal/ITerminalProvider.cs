namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProvider
	{
		/// <summary>
		/// Processes a request and returns a response string
		/// </summary>
		/// <returns>a response string</returns>
		/// <param name="requestCommand">Request command.</param>
		string ProcessCommand (TerminalRequestCommand requestCommand);
	}
}