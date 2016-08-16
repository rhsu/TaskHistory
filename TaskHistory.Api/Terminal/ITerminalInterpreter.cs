using System.Collections.Generic;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalInterpreter
	{
		TerminalCommandResponse InterpretStringCommand (string requestCommand);

		IEnumerable<ITerminalObject> PerformReadOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject);

		int PerformInsertOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject);

		int PerformUpdateOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject);

		int PerformDeleteOperation(TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject);
	}
}