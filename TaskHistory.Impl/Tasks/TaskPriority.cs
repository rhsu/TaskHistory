using TaskHistory.Api.Tasks;

namespace TaskHistory.Impl
{
	public class TaskPriority : ITaskPriority
	{
		int _id;
		string _name;
		int _rank;
		int _userId;

		public int Id { get { return _id; } }

		public string Name { get { return _name; } }

		public int Rank { get { return _rank; } }

		public int UserId { get { return _userId; } }


		// TODO .NET now supports named parameter args
		//		how do I do that?
		public TaskPriority(int id, int userId, int rank, string name)
		{
			_id = id;
			_userId = userId;
			_name = name;
			_rank = rank;
		}
	}
}