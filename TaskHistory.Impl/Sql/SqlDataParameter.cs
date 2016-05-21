using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class SqlDataParameter : ISqlDataParameter
	{
		public string ParamName { get; private set; }

		public object Value { get; private set; }

		public SqlDataParameter (string name, object value)
		{
			this.ParamName = name;
			this.Value = value;
		}
	}
}