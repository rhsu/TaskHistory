using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class DataParameter : ISqlDataParameter
	{
		public string ParamName { get; }

		public object Value { get; }

		public DataParameter(string name, object value)
		{
			this.ParamName = name;
			this.Value = value;
		}
	}
}