using System;
using TaskHistory.Api.Terminal;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalObjectMapper
	{
		public ITerminalObject ConvertTask (ITask task)
		{
			if (task == null)
				throw new ArgumentNullException ("task");
			return null;
		}

		public ITerminalObject ConvertLabel ()
		{
			return null;
		}

		public TerminalObjectMapper ()
		{
		}
	}
}

