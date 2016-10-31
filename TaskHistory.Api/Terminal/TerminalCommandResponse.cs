using System.Collections.Generic;

namespace TaskHistory.Api.Terminal
{
	public struct TerminalCommandResponse
	{
		public TerminalCommandAction CommandAction { get; }
		public TerminalRegisteredObject RegisteredObject { get; }
		public string CommandOptions { get; }

		//public IEnumerable<string> CommandOptionsL { get; }

		public TerminalCommandResponse(TerminalCommandAction action,
			TerminalRegisteredObject registeredObj,
		                               string opt)
           //IEnumerable<string> commandOptionsL)
		{
			CommandAction = action;
			RegisteredObject = registeredObj;
			CommandOptions = opt;
			//CommandOptionsL = commandOptionsL;
		}
	}
}