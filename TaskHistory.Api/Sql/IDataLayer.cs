using System;
using System.Collections.Generic;

namespace TaskHistory.Api.Sql
{
	public interface IDataLayer
	{
		T ExecuteReader<T> (IFromDataReaderFactory<T> factory, string storedProcedureName, IEnumerable<ISqlDataParameter> parameters);
	}
}

