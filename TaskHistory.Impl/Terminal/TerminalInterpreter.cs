using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskHistory.Api.Terminal;
using TaskHistory.Api.Users;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalInterpreter : ITerminalInterpreter
	{
		private readonly ITerminalProxyRepo _terminalProxyRepo;
		const string _default_display_message = "Please Enter a Command. (Type HELP for more options)";

		public string GetDefaultDisplayMessage()
		{
			return _default_display_message;
		}

		public string TranslateResponseToString (string requestCommand, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException (nameof(user));

			//TODO Test me if null or empty is given, then returns "No Command Received"
			if (string.IsNullOrEmpty (requestCommand))
				return "No Command Received";

			// 1. Tokenize the string
			//TODO Test me if tokenizedString is less than 2 words, then ...
			string[] tokenizedString = requestCommand.ToUpper ().Trim ().Split (' ');
			if (tokenizedString.Length < 2)
				return $"{requestCommand} is invalid. " + _default_display_message;

			//2. Get the first word of the request command
			string firstWord = tokenizedString[0];
			// -- it should be create, read, update, delete, or help
			// TODO Test all the possible strings and one thing that is not valid
			TerminalCommandAction commandAction = TerminalInterpreterHelper.DetermineTerminalCommandAction(firstWord);
			if (commandAction == TerminalCommandAction.Error)
				return $"{commandAction} is invalid " + _default_display_message;

			//3 get the second word of the request command
			string secondWord = tokenizedString[1];
			// --it should be label, task, or user
			TerminalRegisteredObject registeredObject = TerminalInterpreterHelper.DetermineTerminalRegisteredObject(secondWord);
			if (registeredObject == TerminalRegisteredObject.Error)
				return $"{registeredObject} is invalid " + _default_display_message;

			//TODO Integrate the two checks. For example "Pig Latin" will return Pig is not a valid action. Latin is not a valid object

			//4 figure out the option string
			string optionString = TerminalInterpreterHelper.ParseOptionText (tokenizedString);

			var commandResponse = new TerminalCommandResponse(commandAction, registeredObject, optionString);

			var returnVal = InterpretCommandResponse (commandResponse, user);
			if (string.IsNullOrEmpty (returnVal))
				throw new NullReferenceException ("Null returned from Interpreting CommandResponse");

			return returnVal;
		}

		private string InterpretCommandResponse(TerminalCommandResponse commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException (nameof(user));
			
			switch (commandResponse.CommandAction) 
			{
			case TerminalCommandAction.Delete:
				int numDeleted = _terminalProxyRepo.PerformDeleteOperation (commandResponse, user);
				return $"{numDeleted} records were deleted.";

			case TerminalCommandAction.List:
				IEnumerable<ITerminalObject> objectsRead = _terminalProxyRepo.PerformReadOperation (commandResponse, user);
				if (objectsRead == null)
					throw new NullReferenceException("Null returned from ProxyRepo");
				if (objectsRead.Count() == 0)
				{
					return $"No {commandResponse.RegisteredObject}s found";
				}
				var builder = new StringBuilder ();

				foreach (var obj in objectsRead) {
					builder.Append ($"{obj.ObjectId}: {obj.ObjectName} <br />");
				}

				return builder.ToString ();

			case TerminalCommandAction.Update:
				int numUpdated = _terminalProxyRepo.PerformUpdateOperation (commandResponse, user);
				return $"{numUpdated} records were deleted.";

			case TerminalCommandAction.Insert:
				int numInserted = _terminalProxyRepo.PerformCreateOperation (commandResponse, user);
				return $"{numInserted} records were inserted.";
			}

			return string.Empty;
		}

		public TerminalInterpreter(ITerminalProxyRepo proxyRepo)
		{
			_terminalProxyRepo = proxyRepo;
		}
	}
}