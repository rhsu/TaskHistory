using System;
using TaskHistory.Api.Terminal;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalObject : ITerminalObject
	{
		public int ObjectId { get; }
		public string ObjectName { get; }

		public TerminalObject (int id, string name)
		{
			this.ObjectId = id;
			this.ObjectName = name;
		}
	}
}

