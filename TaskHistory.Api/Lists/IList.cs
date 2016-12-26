using System.Collections.Generic;
using TaskHistory.Api.Tasks;

namespace TaskHistory.Api.Lists
{
	public class IList
	{
		int ListId { get; }
		IEnumerable<ITask> Tasks { get; }
	}
}