using System;
using System.Collections.Generic;

namespace TaskHistory.Api.Sql
{
	public interface IDataLayer<TSqlParam>
	{
		T ExecuteReader<T> (IFromDataReaderFactory<T> factory, string storedProcedureName, IEnumerable<IDataParameter<TSqlParam>> parameters);
	}
}

