using System;
using TaskHistory.Api.Terminal;
using TaskHistory.Api.Users;

namespace TaskHistoryOrchestrator
{
	public class TerminalOrchestrator
	{
		private ITerminalInterpreter _terminalInterpreter;

		public TerminalOrchestrator(ITerminalInterpreter terminalInterpreter)
		{
			_terminalInterpreter = terminalInterpreter;
		}

		public string ProcessCommand(string command, IUser user)
		{
			if (string.IsNullOrEmpty(command))
			{
				return "Invalid Command";
			}

			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var returnString = _terminalInterpreter.TranslateResponseToString(command, user);

			return returnString;
		}
	}
}