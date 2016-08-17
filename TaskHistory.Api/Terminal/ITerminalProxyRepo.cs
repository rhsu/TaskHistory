using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		int PerformCreateOperation(TerminalCommandOption commandOption, 
			TerminalRegisteredObject registeredObject,
			IUser user);

		/* IEnumerable<ITerminalObject> PerformReadOperation(TerminalCommandOption commandOption, 
			TerminalRegisteredObject registeredObject, 
			IUser user);

		int PerformUpdateOperation (TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject);

		int PerformDeleteOperation (TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject); */
	}
}