namespace TaskHistory.Api.Terminal
{
	public struct TerminalCommandResponse2
	{
		public TerminalCommandAction CommandAction { get; }
		public TerminalRegisteredObject RegisteredObject { get; }
		public string CommandOptions { get; }

		public TerminalCommandResponse2(TerminalCommandAction action,
			TerminalRegisteredObject registeredObj,
			string opt)
		{
			CommandAction = action;
			RegisteredObject = registeredObj;
			CommandOptions = opt;
		}
	}


	// TODO This should probably be a struct
	public class TerminalCommandResponse
	{
		private TerminalCommandAction _terminalCommandAction;
		private TerminalRegisteredObject _registeredObject;
		private TerminalCommandOption _commandOption;

		public TerminalCommandAction TerminalRequest 
		{ 
			get { return _terminalCommandAction; }
		}

		public TerminalRegisteredObject TheObject 
		{ 
			get { return _registeredObject; } 
		}

		public TerminalCommandOption TerminalCommandOption
		{
			get { return _commandOption; }
		}


		public TerminalCommandResponse (TerminalCommandAction terminalCommandAction, 
			TerminalRegisteredObject registeredObject, 
			TerminalCommandOption commandOption)
		{
			_terminalCommandAction = terminalCommandAction;
			_registeredObject = registeredObject;
			_commandOption = commandOption;
		}

		public static TerminalCommandResponse ErrorResponse = new TerminalCommandResponse(TerminalCommandAction.Error,
			TerminalRegisteredObject.Error, 
			TerminalCommandOption.None);
	}
}