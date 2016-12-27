using System.Collections.Generic;
using TaskHistory.Api.Lists;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl.Lists
{
	public class List : IList
	{
		public int ListId { get; }
		public IEnumerable<ITask> Tasks { get; }

		public List(int listId, IEnumerable<ITask> tasks)
		{
			this.ListId = listId;
			this.Tasks = tasks;
		}
	}
}