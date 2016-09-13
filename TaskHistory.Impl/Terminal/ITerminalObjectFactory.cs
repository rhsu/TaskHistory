using System;
using TaskHistory.Api.Terminal;

namespace TaskHistory.Impl.Terminal
{
	public interface ITerminalObjectFactory
	{
		ITerminalObject Create(int id, string name);
	}
}