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

			//TODO: Remove me someday if stable
			if (value == null)
				throw new ArgumentNullException(nameof(value), "This can be uncommented if this is causing existing issues");

			return new SqlDataParameter(paramName, value);
		}
	}
}

