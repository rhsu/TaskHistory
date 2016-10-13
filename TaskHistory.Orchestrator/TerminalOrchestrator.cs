using System;
using TaskHistory.Api.Terminal;
using TaskHistory.Api.Users;

namespace TaskHistoryOrchestrator
{
	public class TerminalOrchestrator
	{
		private ITerminalInterpreter _terminalInterpreter;

		public TerminalOrchestrator (ITerminalInterpreter terminalInterpreter)
		{
			_terminalInterpreter = terminalInterpreter;
		}

		public string ProcessCommand(string command, IUser user)
		{
			if (command == null || command == string.Empty) 
			{
				return "Invalid Command";
			}

			var returnString = _terminalInterpreter.TranslateResponseToString(command, user);

			return returnString;
		}
	}
}