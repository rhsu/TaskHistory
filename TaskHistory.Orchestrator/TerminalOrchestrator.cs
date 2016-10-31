using System;
using TaskHistory.Api.Terminal;
using TaskHistory.Api.Users;

namespace TaskHistoryOrchestrator
{
	public class TerminalOrchestrator
	{
		ITerminalInterpreter _terminalInterpreter;

		public TerminalOrchestrator(ITerminalInterpreter terminalInterpreter)
		{
			_terminalInterpreter = terminalInterpreter;
		}

		public string GetDefaultDisplayMessage()
		{
			return _terminalInterpreter.GetDefaultDisplayMessage();
		}

		public string ProcessCommand(string command, IUser user)
		{
			if (string.IsNullOrEmpty(command))
			{
				return "Invalid Command: " + _terminalInterpreter.GetDefaultDisplayMessage();
			}

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var returnString = _terminalInterpreter.TranslateResponseToString(command, user);

			return returnString;
		}
	}
}