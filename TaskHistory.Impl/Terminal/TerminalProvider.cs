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
		public string ProcessCommand (string requestInput)
		{
			string[] tokenizedString = requestInput.ToUpper().Trim().Split (',');

			TerminalRequestCommand requestCommand = TerminalRequestCommand.ERROR;

			Enum.TryParse<TerminalRequestCommand> (tokenizedString [0], requestCommand);

			switch (requestCommand) 
			{
				case TerminalRequestCommand.LIST:
					break;
				case TerminalRequestCommand.DELETE:
					break;
				case TerminalRequestCommand.INSERT:
					break;
				case TerminalRequestCommand.UPDATE:
					break;
				case TerminalRequestCommand.ERROR:
					return invalidCommandResponse;
					break;
			}

			throw new NotImplementedException ("Not done yet");
		}

		public TerminalProvider ()
		{
		}
	}
}