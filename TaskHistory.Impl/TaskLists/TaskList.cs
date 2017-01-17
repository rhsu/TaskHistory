namespace TaskHistory.Impl
{
	public class TaskList
	{
		public int Id { get; }
		public string Name { get; }

		public TaskList(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}
