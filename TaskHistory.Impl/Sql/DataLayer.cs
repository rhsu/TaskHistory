using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TaskHistory.Impl.MySql
{
	public class DataLayer
	{
		private DataParameterCollectionFactory _dataParameterCollectionFactory;

		public T ExecuteReader<T> (IFromDataReaderFactory<T> factory, 
			string storedProcedureName,
			IEnumerable<MySqlParameter> parameters)
		{
			return null;
		}

		public void ExecuteNonQuery()
		{
		}

		public DataLayer ()
		{
		}
	}
}

