using System;
using TaskHistoryApi.Tasks;
using System.Collections.Generic;
using TaskHistoryApi.Labels;

namespace TaskHistoryApi.TasksComplex
{
	public interface ITaskComplex : ITask
	{
		IEnumerable<ILabel> Labels { get; }
	}
}