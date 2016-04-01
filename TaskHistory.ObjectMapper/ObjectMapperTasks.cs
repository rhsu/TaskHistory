using System.Collections.Generic;
using TaskHistory.ViewModel.Tasks;
using TaskHistory.Api.Tasks;
using System;

namespace TaskHistoryObjectMapper
{
	public class ObjectMapperTasks
	{
		public IEnumerable<TaskDisplayForGridViewViewModel> Map (IEnumerable<ITask> tasks)
		{
			if (tasks == null)
				throw new ArgumentNullException ("tasks");

			return null;
		}

		public ObjectMapperTasks ()
		{
		}
	}
}