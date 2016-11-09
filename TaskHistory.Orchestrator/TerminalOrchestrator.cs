using System;
using System.Collections.Generic;
using TaskHistory.Api.Terminal;
using TaskHistory.Api.Users;

namespace TaskHistoryOrchestrator
{
	public class TerminalOrchestrator
	{
		readonly ITerminalInterpreter _terminalInterpreter;

		public TerminalOrchestrator(ITerminalInterpreter terminalInterpreter)
		{
			_terminalInterpreter = terminalInterpreter;
		}

		public string GetDefaultDisplayMessage()
		{
			return _terminalInterpreter.GetDefaultDisplayMessage();
		}

		public IEnumerable<string> ProcessCommand(string command, IUser user)
		{
			if (string.IsNullOrEmpty(command))
			{
				return new List<string> { "Invalid Command: " + _terminalInterpreter.GetDefaultDisplayMessage()};
			}

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var returnString = _terminalInterpreter.TranslateResponseToString(command, user);

			return returnString;
		}
	}
}