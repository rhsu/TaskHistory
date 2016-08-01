using TaskHistory.Api.Terminal;
using System;

namespace TaskHistory.Impl.TerminalProvider
{
	public class TerminalProvider : ITerminalProvider
	{
		private const string invalidCommandResponse = "Invalid command detected";

		/// <summary>
		/// Processes a request and returns a response string
		/// </summary>
		/// <returns>a response string</returns>
		/// <param name="requestCommand">Request command.</param>
		public TerminalCommandRequest ProcessCommand (string requestInput)
		{
			/*string[] tokenizedString = requestInput.ToUpper().Trim().Split (',');

			TerminalRequestCommand requestCommand = TerminalRequestCommand.Error;

			Enum.TryParse<TerminalRequestCommand> (tokenizedString [0], requestCommand);

			switch (requestCommand) 
			{

			case TerminalRequestCommand.List:
					break;
			case TerminalRequestCommand.Delete:
					break;
			case TerminalRequestCommand.Insert:
					break;
			case TerminalRequestCommand.Update:
					break;
			case TerminalRequestCommand.Error:
					return invalidCommandResponse;
					break;
			}*/

			throw new NotImplementedException ("Not done yet");
		}

		public TerminalProvider ()
		{
		}
	}
}