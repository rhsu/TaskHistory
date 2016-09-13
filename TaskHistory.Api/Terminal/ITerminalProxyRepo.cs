using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		int PerformCreateOperation(TerminalCommandResponse commandResponse, IUser user);

		IEnumerable<ITerminalObject> PerformReadOperation (TerminalCommandResponse commandResponse, IUser user);

		int PerformUpdateOperation (TerminalCommandResponse commandResponse, IUser user);

		int PerformDeleteOperation (TerminalCommandResponse commandResponse, IUser user);
	}
}