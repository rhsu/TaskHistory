using System;
using System.Collections.Generic;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		// TODO: demystify this magic string
		IEnumerable<ITerminalObject> ReadTerminalObjects(string magicString);
	}
}