using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class SqlParameterFactory
	{
		public ISqlDataParameter CreateParameter(string paramName, object value)
		{
			return new SqlDataParameter(paramName, value);
		}

		public SqlParameterFactory ()
		{
		}
	}
}

