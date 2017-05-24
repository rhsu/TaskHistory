using System;
namespace TaskHistory.Api.Tasks
{
	public interface ITaskPriority
	{
		int Id { get; }
		int UserId { get; }
		string Name { get; }
	}
}
