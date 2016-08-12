using TaskHistory.Api.Terminal;
using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Impl.Terminal
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
			TerminalCommandAction commandAction = TerminalProviderHelper.DetermineTerminalCommandAction(tokenizedString[0]);
			if (commandAction == TerminalCommandAction.Error)
				return TerminalCommandResponse.ErrorResponse;

			// 3. Determine the Object
			TerminalRegisteredObject registeredObject = TerminalProviderHelper.DetermineTerminalRegisteredObject(tokenizedString[1]);
			if (registeredObject == TerminalRegisteredObject.Error)
				return TerminalCommandResponse.ErrorResponse;
		
			// 4. Determine the Option
			TerminalCommandOption commandOption = TerminalProviderHelper.DetermineTerminalCommandOption(tokenizedString[2]);

			// 5. Still here? Then let's construct a TerminalCommandResponse
			// TODO factory me for unit testing
			var returnVal = new TerminalCommandResponse(commandAction, registeredObject, commandOption);

			return returnVal;
		}

		// Translate TerminalCommandResponse to IEnumerable of TerminalObjects
		public IEnumerable<ITerminalObject> TranslateTerminalCommandResponse(TerminalCommandResponse commandResponse)
		{
			if (commandResponse == null)
				throw new ArgumentNullException ("commandResponse");

			if (commandResponse == TerminalCommandResponse.ErrorResponse)
				throw new ArgumentOutOfRangeException ("commandResponse", "ErrorResponse detected");

			var returnVal = new List<ITerminalObject> ();

			// IRepo repo = null;

			switch (commandResponse.TheObject) 
			{
			case TerminalRegisteredObject.Task:
				//IRepo repo = taskRepo;
				break;
			case TerminalRegisteredObject.User:
				//IRepo repo = userRepo
				break;
			}



			return returnVal;
		}


		public Type DetermineType(int testNum)
		{
			switch (testNum) 
			{
			case 1:
				return typeof(IUser);
			case 2:
				break;
			}

			return null;
		}

		/*public void Test()
		{
			var t = DetermineType (1);

			IEnumerable<t> stuff = new List<t> ();
		}

		public static IEnumerable<int> TestFunction(int i)
		{
			return null;
		}


		public static Func<int, IEnumerable<int>> Test()
		{

			return TestFunction;
		}

		public static void Bench()
		{
			var thing = Test ();

			thing.Invoke (5);
		}*/




		public TerminalProvider ()
		{
		}
	}
}