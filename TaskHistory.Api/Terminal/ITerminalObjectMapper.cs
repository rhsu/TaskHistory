using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Labels;
using System.Collections.Generic;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalObjectMapper
	{
		//TODO instead of doing it this way. use attributes
		ITerminalObject ConvertTask(IEnumerable<ITask> task);

		ITerminalObject ConvertLabel(IEnumerable<ILabel> label);
	}
}