using System;
using System.Collections.Generic;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		void PerformActionForResponse(TerminalCommandResponse commandResponse);

		// TODO: demystify this magic string
		IEnumerable<ITerminalObject> ReadTerminalObjects(string magicString);
	}
}