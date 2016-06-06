using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.Sql
{
	// RH [TODO] Wrap DataReaderProvider and ParamFactory together since they are always used together
	public class ApplicationDataProvider
	{
		private readonly IDataReaderProvider _dataReaderProvider;
		private readonly SqlParameterFactory _paramFactory;

		public ApplicationDataProvider (IDataReaderProvider dataReaderProvider, 
			SqlParameterFactory paramFactory)
		{
			_dataReaderProvider = dataReaderProvider;
			_paramFactory = paramFactory;
		}

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException ("storedProcedureName");

			if (parameter == null)
				throw new ArgumentNullException ("parameter");

			var returnVal = _dataReaderProvider.
		}

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory, 
			string storedProcedureName, 
			IEnumerable<ISqlDataParameter> parameters);

		public IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter);

		public IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters);
	}
}