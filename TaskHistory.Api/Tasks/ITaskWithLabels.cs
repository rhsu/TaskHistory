using System.Collections.Generic;
using TaskHistory.Api.Labels;

namespace TaskHistory.Api.Tasks
{
	public interface ITaskWithLabels : ITask
	{
		IEnumerable<ILabel> Labels { get; }
	}
}