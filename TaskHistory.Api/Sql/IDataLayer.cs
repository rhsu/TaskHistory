using System;
using System.Collections.Generic;

namespace TaskHistory.Api.Sql
{
	public interface IDataLayer
	{
		T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter);

		T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory, 
			string storedProcedureName, 
			IEnumerable<ISqlDataParameter> parameters);

		IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter);

		IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters);
	}
}