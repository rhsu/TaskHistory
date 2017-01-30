using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalInterpreter
	{
		/// <summary>
		/// Interprets the string command. example create label -name "Value
		/// </summary>
		/// <returns>a string response.</returns>
		/// <param name="user">the user making the request</param>
		/// <param name="requestCommand">Request command.</param>
		IEnumerable<string> TranslateResponseToString (string requestCommand, IUser user);

		/// <summary>
		/// Returns the default message to display to the user
		/// </summary>
		/// <returns>The default display message.</returns>
		string GetDefaultDisplayMessage();
	}
}