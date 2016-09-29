using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.TasksComplex
{
	public interface ITaskComplex : ITask
	{
		IEnumerable<ILabel> Labels { get; }
	}
}