using System;

namespace TaskHistoryApi.Tasks
{
	public interface ITask
	{
		int TaskId { get; }
		string Content { get; }
		bool IsCompleted { get; }
	}
}