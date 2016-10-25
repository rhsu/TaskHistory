using System;
using System.Collections.Generic;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public class ApplicationDataProxy
	{
		readonly IDataReaderProvider _dataReaderProvider;
		readonly SqlParameterFactory _parameterFactory;
		readonly INonQueryDataProvider _nonQueryDataProvider;

		public T ExecuteReaderForSingleType<T>(IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException(nameof(parameter));

			return _dataReaderProvider.ExecuteReaderForSingleType(factory,
																  storedProcedureName,
																  parameter);
		}

		public T ExecuteReaderForSingleType<T>(IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			return _dataReaderProvider.ExecuteReaderForSingleType(factory,
																  storedProcedureName,
																  parameters);
		}

		/*public IEnumerable<T> ExecuteReaderForTypeCollection<T>(IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter);

		public IEnumerable<T> ExecuteReaderForTypeCollection<T>(IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters);*/

		public ApplicationDataProxy (IDataReaderProvider dataReaderProvider, 
			SqlParameterFactory paramFactory,
			NonQueryDataProvider nonQueryDataProvider)
		{
			_dataReaderProvider = dataReaderProvider;
			_parameterFactory = paramFactory;
			_nonQueryDataProvider = nonQueryDataProvider;
		}
	}
}