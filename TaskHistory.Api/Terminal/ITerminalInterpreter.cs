using System.Collections.Generic;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalInterpreter
	{
		//TerminalCommandResponse InterpretStringCommand (string requestCommand);

		/// <summary>
		/// Interprets the string command. example create label -name "Value
		/// </summary>
		/// <returns>a string response.</returns>
		/// <param name="requestCommand">Request command.</param>
		string TranslateResponseToString (string requestCommand);
	}
}