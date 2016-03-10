using System;
using TaskHistoryApi.Tasks;

namespace TaskHistoryImpl.Task
{
	public class Task : ITask
	{
		public int TaskId 
		{
			get;
		}

		public string Content 
		{
			get;
		}

		public bool IsCompleted 
		{
			get;
		}

		public Task (int taskId, string content, bool isCompleted)
		{
			
		}
	}
}