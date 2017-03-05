using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class SqlParameterFactory : ISqlParameterFactory
	{
		public ISqlDataParameter CreateParameter(string paramName, object value)
		{
			if (paramName == null)
				throw new ArgumentNullException(nameof(paramName));
			
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return new SqlDataParameter(paramName, value);
		}
	}
}

