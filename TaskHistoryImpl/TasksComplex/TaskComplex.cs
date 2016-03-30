using TaskHistory.Api.TasksComplex;
using System.Collections.Generic;
using TaskHistory.Api.Labels;
using TaskHistory.Api.Tasks;
using TaskHistoryImpl.Tasks;

namespace TaskHistoryImpl.TasksComplex
{
	public class TaskComplex : Task, ITaskComplex
	{
		public IEnumerable<ILabel> Labels { get; }
			
		public TaskComplex (int taskId, string content, bool isCompleted, IEnumerable<ILabel> labels)
			: base (taskId, content, isCompleted)
		{
			Labels = labels;
		}
	}
}