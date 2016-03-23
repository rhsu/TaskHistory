using System;
using TaskHistoryApi.TasksComplex;
using System.Collections.Generic;
using TaskHistoryApi.Labels;

namespace TaskHistoryImpl.TasksComplex
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