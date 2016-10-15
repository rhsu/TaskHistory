using TaskHistory.Api.Terminal;
using System;
using System.Text;

namespace TaskHistory.Impl.Terminal
{
	/// <summary>
	/// Helper Functions Available for the Terminal Provider
	/// </summary>
	//TODO: This should not be a static class
	public static class TerminalInterpreterHelper
	{
		internal static TerminalCommandAction DetermineTerminalCommandAction(string commandActionString)
		{
			if (string.IsNullOrEmpty (commandActionString))
				return TerminalCommandAction.Error;

			TerminalCommandAction requestCommand = TerminalCommandAction.Error;
			Enum.TryParse (commandActionString, out requestCommand);

			return requestCommand;
		}

		public static TerminalRegisteredObject DetermineTerminalRegisteredObject(string registeredObjectString)
		{
			if (string.IsNullOrEmpty (registeredObjectString))
				return TerminalRegisteredObject.Error;

			TerminalRegisteredObject registeredObject = TerminalRegisteredObject.Error;
			Enum.TryParse (registeredObjectString, true, out registeredObject);

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

		internal static string ParseOptionText(string[] requestInput)
		{
			if (requestInput == null)
				throw new ArgumentNullException ("requestInput");

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

