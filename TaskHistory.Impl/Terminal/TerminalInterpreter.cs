using TaskHistory.Api.Terminal;
using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Sql;
using System.Text;

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
			//TODO Test me if null or empty is given, then returns "No Command Received"
			if (string.IsNullOrEmpty (requestCommand))
				return "No Command Received";

			// 1. Tokenize the string
			//TODO Test me if tokenizedString is less than 2 words, then ...
			string[] tokenizedString = requestCommand.ToUpper ().Trim ().Split (' ');
			if (tokenizedString.Length < 2)
				return $"{requestCommand} is invalid";

			//2. Get the first word of the request command
			string firstWord = tokenizedString[0];
			// -- it should be create, read, update, delete, or help
			// TODO Test all the possible strings and one thing that is not valid
			TerminalCommandAction commandAction = TerminalInterpreterHelper.DetermineTerminalCommandAction(firstWord);
			if (commandAction == TerminalCommandAction.Error)
				return $"{commandAction} is invalid";

			//3 get the second word of the request command
			string secondWord = tokenizedString[1];
			// --it should be label, task, or user
			TerminalRegisteredObject registeredObject = TerminalInterpreterHelper.DetermineTerminalRegisteredObject(secondWord);
			if (registeredObject == TerminalRegisteredObject.Error)
				return $"{registeredObject} is invalid";

			//TODO Integrate the two checks. For example "Pig Latin" will return Pig is not a valid action. Latin is not a valid object

			//4 figure out the option string
			string optionString = TerminalInterpreterHelper.ParseOptionText (tokenizedString);

			var commandResponse = new TerminalCommandResponse2(commandAction, registeredObject, optionString);

			var returnVal = InterpretCommandResponse (commandResponse);
			if (string.IsNullOrEmpty (returnVal))
				throw new NullReferenceException ("Null returned from Interpreting CommandResponse");

			return returnVal;
		}

		private string InterpretCommandResponse(TerminalCommandResponse2 commandResponse)
		{
			if (commandResponse == null)
				throw new ArgumentNullException ("commandResponse");

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