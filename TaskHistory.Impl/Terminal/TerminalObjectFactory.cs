using TaskHistory.Api.Terminal;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalObjectFactory : ITerminalObjectFactory
	{
		public ITerminalObject Create(int id, string name)
		{
			return new TerminalObject(id, name);
		}
	}
}