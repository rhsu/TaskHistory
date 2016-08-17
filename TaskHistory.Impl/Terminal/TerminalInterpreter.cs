using TaskHistory.Api.Terminal;
using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalInterpreter : ITerminalInterpreter
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
			TerminalCommandAction commandAction = TerminalInterpreterHelper.DetermineTerminalCommandAction(tokenizedString[0]);
			if (commandAction == TerminalCommandAction.Error)
				return TerminalCommandResponse.ErrorResponse;

			// 3. Determine the Object
			TerminalRegisteredObject registeredObject = TerminalInterpreterHelper.DetermineTerminalRegisteredObject(tokenizedString[1]);
			if (registeredObject == TerminalRegisteredObject.Error)
				return TerminalCommandResponse.ErrorResponse;
		
			// 4. Determine the Option
			TerminalCommandOption commandOption = TerminalInterpreterHelper.DetermineTerminalCommandOption(tokenizedString[2]);

			// 5. Still here? Then let's construct a TerminalCommandResponse
			// TODO factory me for unit testing
			var returnVal = new TerminalCommandResponse(commandAction, registeredObject, commandOption);

			return returnVal;
		}
			
		public TerminalInterpreter (ITerminalProxyRepo proxyRepo)
		{
		}
	}
}