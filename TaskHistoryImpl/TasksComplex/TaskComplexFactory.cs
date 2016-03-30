using System;
using TaskHistory.Api.TasksComplex;
using System.Collections.Generic;
using TaskHistory.Api.Labels;

namespace TaskHistory.Impl.TasksComplex
{
	public class TaskComplexFactory
	{
		internal ITaskComplex CreateTaskComplex(int taskId, string content, bool isCompleted, IEnumerable<ILabel> labels)
		{
			if (labels == null)
				throw new ArgumentNullException ("labels");

			return new TaskComplex (taskId, content, isCompleted, labels);
		}

		public TaskComplexFactory ()
		{
		}
	}
}