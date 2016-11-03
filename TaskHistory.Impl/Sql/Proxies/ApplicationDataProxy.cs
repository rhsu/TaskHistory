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

		public IEnumerable<T> ExecuteReaderForTypeCollection<T>(IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException(nameof(parameter));

			return _dataReaderProvider.ExecuteReaderForTypeCollection(factory,
																	  storedProcedureName,
																	  parameter);

		}

		public IEnumerable<T> ExecuteReaderForTypeCollection<T>(IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			return _dataReaderProvider.ExecuteReaderForTypeCollection(factory,
																	  storedProcedureName,
																	  parameters);
		}

		public void ExecuteNonQuery(string storedProcedureName)
		{
			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));
			
			_nonQueryDataProvider.ExecuteNonQuery(storedProcedureName);
		}

		public void ExecuteNonQuery(string storedProcedureName, ISqlDataParameter parameter)
		{
			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException(nameof(parameter));

			_nonQueryDataProvider.ExecuteNonQuery(storedProcedureName, parameter);
		}

		public void ExecuteNonQuery(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters)
		{
			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			_nonQueryDataProvider.ExecuteNonQuery(storedProcedureName, parameters);
		}

		public ISqlDataParameter CreateParameter(string paramName, object value)
		{
			if (paramName == null)
				throw new ArgumentNullException(nameof(paramName));

			//TODO: Remove me someday if stable
			if (value == null)
				throw new ArgumentNullException(nameof(value), "This can be uncommented if this is causing existing issues");

			return _parameterFactory.CreateParameter(paramName, value);
		}

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