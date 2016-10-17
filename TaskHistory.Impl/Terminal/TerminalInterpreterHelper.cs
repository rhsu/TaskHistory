using TaskHistory.Api.Terminal;
using System;
using System.Text;

namespace TaskHistory.Impl.Terminal
{
	/// <summary>
	/// Helper Functions Available for the Terminal Provider
	/// </summary>
	public static class TerminalInterpreterHelper
	{
		public static TerminalCommandAction DetermineTerminalCommandAction(string commandActionString)
		{
			if (string.IsNullOrEmpty (commandActionString))
				return TerminalCommandAction.Error;

			TerminalCommandAction requestCommand = TerminalCommandAction.Error;
			bool isSuccessful = Enum.TryParse (commandActionString, true, out requestCommand);

			if (!isSuccessful)
				return TerminalCommandAction.Error;

			return requestCommand;
		}

		public static TerminalRegisteredObject DetermineTerminalRegisteredObject(string registeredObjectString)
		{
			if (string.IsNullOrEmpty (registeredObjectString))
				return TerminalRegisteredObject.Error;

			TerminalRegisteredObject registeredObject = TerminalRegisteredObject.Error;
			bool isSuccessful = Enum.TryParse (registeredObjectString, true, out registeredObject);

			if (!isSuccessful)
				return TerminalRegisteredObject.Error;

			return registeredObject;
		}

		internal static string ParseOptionText(string[] requestInput)
		{
			if (requestInput == null)
				throw new ArgumentNullException (nameof(requestInput));

			if (requestInput.Length < 2)
				throw new InvalidOperationException ($"Cannot Parse Request Input: {requestInput}. Must have length 2 or greater");

			var optionString = new StringBuilder ();

			// TODO Figure out better way to do this. Remove the first two words in a sentence. Maybe the requestInput doesn't have to be an array?
			for (var i = 2; i < requestInput.Length; i++) 
			{
				var currentWord = requestInput [i];
				optionString.Append($"{currentWord} ");
			}

			return optionString.ToString ();
		}
	}
}

