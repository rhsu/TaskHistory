using System.Collections.Generic;

namespace TaskHistory.Api.Sql
{
	public interface IDataNonQueryProvider
	{
		void ExecuteNonQuery (string storedProcedureName);

		void ExecuteNonQuery(string storedProcedureName, ISqlDataParameter parameter);

		void ExecuteNonQuery(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters);
	}
}