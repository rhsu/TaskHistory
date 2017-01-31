using System.Collections.Generic;

namespace TaskHistory.Api.Sql
{
	public interface INonQueryDataProvider
	{
		int Execute (string storedProcedureName);

		int Execute(string storedProcedureName, ISqlDataParameter parameter);

		int Execute(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters);
	}
}