using System;
using TaskHistory.Api.Terminal;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Labels;
using System.Collections.Generic;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalObjectMapper : ITerminalObjectMapper
	{
		private readonly ITerminalObjectFactory _terminalObjectFactory;

		public ITerminalObject ConvertTasks (IEnumerable<ITask> tasks)
		{
			if (tasks == null)
				throw new ArgumentNullException ("task");

			var returnVal = new List<ITerminalObject> ();

			foreach (var task in tasks) 
			{
				var terminalObj = this.ConvertTask (task);
				if (terminalObj == null)
					throw new NullReferenceException ("Null returned when converting task");

				returnVal.Add (terminalObj);
			}

			return returnVal;
		}

		public ITerminalObject ConvertTask (ITask task)
		{
			if (task == null)
				throw new ArgumentNullException ("task");

			var returnVal = _terminalObjectFactory.Create (task.TaskId, task.Content);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from Terminal Object Factory");

			return returnVal;
		}

		public ITerminalObject ConvertLabel (ILabel label)
		{
			if (label == null)
				throw new ArgumentNullException ("task");

			var returnVal = _terminalObjectFactory.Create (label.LabelId, label.Name);
			if (returnVal == null)
				throw new NullReferenceException ("Null returned from Terminal Object Factory");

			return returnVal;
		}

		public TerminalObjectMapper (ITerminalObjectFactory terminalObjectFactory)
		{
			if (ITerminalObjectFactory == null)
				throw new ArgumentNullException ("terminalObjectFactory");

			_terminalObjectFactory = terminalObjectFactory;
		}
	}
}