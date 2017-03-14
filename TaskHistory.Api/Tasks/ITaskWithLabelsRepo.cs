using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Tasks
{
	public interface ITaskWithLabelsRepo
	{
		IEnumerable<ITaskWithLabels> Read(IUser user);
	}
}