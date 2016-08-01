using TaskHistory.Api.Terminal;
using System;

namespace TaskHistory.Impl.TerminalProvider
{
	public class TerminalProvider : ITerminalInterpreter
	{
		public TerminalCommandResponse InterpretStringCommand (string requestInput)
		{
			if (string.IsNullOrEmpty (requestInput))
				return TerminalCommandResponse.ErrorResponse;

			// 1. Tokenize the string
			string[] tokenizedString = requestInput.ToUpper().Trim().Split (' ');
			if (tokenizedString.Length < 2)
				return TerminalCommandResponse.ErrorResponse;

			// 2. Determine the Action
			TerminalCommandAction commandAction = DetermineTerminalCommandAction(tokenizedString[0]);
			if (commandAction == TerminalCommandAction.Error)
				return TerminalCommandResponse.ErrorResponse;

			// 3. Determine the Object
			TerminalRegisteredObject registeredObject = DetermineTerminalRegisteredObject(tokenizedString[1]);
			if (registeredObject == TerminalRegisteredObject.Error)
				return TerminalCommandResponse.ErrorResponse;
		
			// 4. Determine the Option
			TerminalCommandOption commandOption = DetermineTerminalCommandOption(tokenizedString[2]);

			// 5. Still here? Then let's construct a TerminalCommandResponse
			// TODO factory me for unit testing
			var returnVal = new TerminalCommandResponse(commandAction, registeredObject, commandOption);

			return returnVal;
		}

		private static TerminalCommandAction DetermineTerminalCommandAction(string commandActionString)
		{
			if (string.IsNullOrEmpty (commandActionString))
				return TerminalCommandAction.Error;
			
			TerminalCommandAction requestCommand = TerminalCommandAction.Error;
			Enum.TryParse (commandActionString, out requestCommand);

			return requestCommand;
		}

		private static TerminalRegisteredObject DetermineTerminalRegisteredObject(string registeredObjectString)
		{
			if (string.IsNullOrEmpty (registeredObjectString))
				return TerminalRegisteredObject.Error;

			TerminalRegisteredObject registeredObject = TerminalRegisteredObject.Error;
			Enum.TryParse (registeredObjectString, out registeredObject);

			return registeredObject;
		}

		private static TerminalCommandOption DetermineTerminalCommandOption(string commandOptionString)
		{
			if (string.IsNullOrEmpty (commandOptionString))
				return TerminalCommandOption.None;

			TerminalCommandOption commandOption = TerminalCommandOption.None;
			Enum.TryParse (commandOptionString, out commandOption);

			return commandOption;
		}


		public TerminalProvider ()
		{
		}
	}
}