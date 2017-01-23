using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class SqlParameterFactory
	{
		public ISqlDataParameter CreateParameter(string paramName, object value)
		{
			if (paramName == null)
				throw new ArgumentNullException(nameof(paramName));

			return new SqlDataParameter(paramName, value);
		}
	}
}

