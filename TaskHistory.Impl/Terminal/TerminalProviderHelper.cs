using TaskHistory.Api.Terminal;
using System;

namespace TaskHistory.Impl.Terminal
{
	/// <summary>
	/// Helper Functions Available for the Terminal Provider
	/// </summary>
	internal static class TerminalProviderHelper
	{
		internal static TerminalCommandAction DetermineTerminalCommandAction(string commandActionString)
		{
			if (string.IsNullOrEmpty (commandActionString))
				return TerminalCommandAction.Error;

			TerminalCommandAction requestCommand = TerminalCommandAction.Error;
			Enum.TryParse (commandActionString, out requestCommand);

			return requestCommand;
		}

		internal static TerminalRegisteredObject DetermineTerminalRegisteredObject(string registeredObjectString)
		{
			if (string.IsNullOrEmpty (registeredObjectString))
				return TerminalRegisteredObject.Error;

			TerminalRegisteredObject registeredObject = TerminalRegisteredObject.Error;
			Enum.TryParse (registeredObjectString, out registeredObject);

			return registeredObject;
		}

		internal static TerminalCommandOption DetermineTerminalCommandOption(string commandOptionString)
		{
			if (string.IsNullOrEmpty (commandOptionString))
				return TerminalCommandOption.None;

			TerminalCommandOption commandOption = TerminalCommandOption.None;
			Enum.TryParse (commandOptionString, out commandOption);

			return commandOption;
		}
	}
}

