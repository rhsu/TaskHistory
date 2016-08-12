using System;
using System.Collections.Generic;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		void PerformActionForResponse(TerminalCommandResponse commandResponse);

		IEnumerable<ITerminalObject> ReadTerminalObjects();
	}
}