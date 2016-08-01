using System;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		void PerformActionForResponse(TerminalCommandResponse commandResponse);
	}
}