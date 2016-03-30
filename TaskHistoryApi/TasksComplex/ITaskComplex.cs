using System;
using TaskHistory.Api.Tasks;
using System.Collections.Generic;
using TaskHistory.Api.Labels;

namespace TaskHistory.Api.TasksComplex
{
	public interface ITaskComplex : ITask
	{
		IEnumerable<ILabel> Labels { get; }
	}
}