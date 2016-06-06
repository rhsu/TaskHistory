namespace TaskHistory.Api.Sql
{
	public interface ISqlDataParameter
	{
		string ParamName { get; }

		object Value { get; }
	}
}