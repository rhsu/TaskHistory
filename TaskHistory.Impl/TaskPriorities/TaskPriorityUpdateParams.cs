using TaskHistory.Api.TaskPriorities;

namespace TaskHistory.Impl.TaskPriorities
{
	public class TaskPriorityUpdateParams : ITaskPriorityUpdateParams
	{
		readonly string _name;
		readonly bool _isDeleted;
		readonly int _rank;

		public TaskPriorityUpdateParams(string name,
										bool isDeleted, 
		                                int rank)
		{
			_name = name;
			_isDeleted = isDeleted;
			_rank = rank;
		}

		public bool IsDeleted
		{
			get { return _isDeleted; }
		}

		public string Name
		{
			get { return _name; }
		}

		public int Rank
		{
			get { return _rank; }
		}
	}
}
