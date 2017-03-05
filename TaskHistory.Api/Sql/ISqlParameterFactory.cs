namespace TaskHistory.Api.Sql
{
	public interface ISqlParameterFactory
	{
		ISqlDataParameter CreateParameter (string paramName, object value);
	}
}