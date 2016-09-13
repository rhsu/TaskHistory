using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		int PerformCreateOperation(TerminalCommandResponse2 commandResponse, IUser user);

		IEnumerable<ITerminalObject> PerformReadOperation (TerminalCommandResponse2 commandResponse, IUser user);

		int PerformUpdateOperation (TerminalCommandResponse2 commandResponse, IUser user);

		int PerformDeleteOperation (TerminalCommandResponse2 commandResponse, IUser user);
	}
}