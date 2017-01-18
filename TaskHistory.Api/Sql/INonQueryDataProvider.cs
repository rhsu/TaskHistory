using System.Collections.Generic;

namespace TaskHistory.Api.Sql
{
	public interface INonQueryDataProvider
	{
		void Execute (string storedProcedureName);

		void Execute(string storedProcedureName, ISqlDataParameter parameter);

		void Execute(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters);
	}
}