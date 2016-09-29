using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalObjectMapper
	{
		//TODO instead of doing it this way. use attributes
		IEnumerable<ITerminalObject> ConvertTasks(IEnumerable<ITask> task);

		IEnumerable<ITerminalObject> ConvertLabels(IEnumerable<ILabel> label);
	}
}