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

		}

		public ITerminalObject ConvertLabel ()
		{
		}

		public TerminalObjectMapper ()
		{
		}
	}
}

