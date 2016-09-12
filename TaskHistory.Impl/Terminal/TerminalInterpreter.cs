using TaskHistory.Api.Terminal;
using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalInterpreter : ITerminalInterpreter
	{
		/// <summary>
		/// Interprets the string command. example create label -name "Value
		/// </summary>
		/// <returns>a string response.</returns>
		/// <param name="requestCommand">Request command.</param>
		public string TranslateResponseToString (string requestCommand)
		{
			if (string.IsNullOrEmpty (requestCommand))
				throw new ArgumentNullException ("requestCommand");

			//1 get the first word of the request command
			// -- it should be create, read, update, delete, or help

			//2 get the second word of the request command
			// --it should be label, task, or user

			//3 create a CommandRequestObject
				//-- crudOperation, --objectType --auxilary options "-name 'Robert'" for example...
				// enum, enum, string

			return null;
		}
	}

	public class TerminalInterpreter_Old //: ITerminalInterpreter
	{
		private TerminalCommandResponse TranslateRequestToResponseObj (string requestInput)
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


		public string TranslateResponseToString(string requestInput)
		{
			//1. translate
			TerminalCommandResponse commandResponse = TranslateRequestToResponseObj (requestInput);
			if (commandResponse == null)
				throw new NullReferenceException ("Null returned when translating the request input");

			//2. Determine the repo operation

			return string.Empty;
		}
			
		public TerminalInterpreter_Old (ITerminalProxyRepo proxyRepo)
		{
		}
	}
}