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

		public T ExecuteReader<T>(IFromDataReaderFactory<T> factory,
							string storedProcedureName)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			return _dataReaderProvider.ExecuteReader(factory,
													 storedProcedureName);
		}

		public T ExecuteReader<T>(IFromDataReaderFactory<T> factory,
		                    string storedProcedureName,
		                    ISqlDataParameter parameter)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException(nameof(parameter));

			return _dataReaderProvider.ExecuteReader(factory,
			                                         storedProcedureName,
			                                         parameter);
		}

		public T ExecuteReader<T>(IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			return _dataReaderProvider.ExecuteReader(factory,
													 storedProcedureName,
													 parameters);
		}

		public IEnumerable<T> ExecuteOnCollection<T>(IFromDataReaderFactory<T> factory,
													 string storedProcedureName)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			return _dataReaderProvider.ExecuteReaderForTypeCollection(factory,
																	  storedProcedureName);
		}

		public IEnumerable<T> ExecuteOnCollection<T>(IFromDataReaderFactory<T> factory,
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

		public IEnumerable<T> ExecuteOnCollection<T>(IFromDataReaderFactory<T> factory,
		                                             string storedProcedureName,
		                                             IEnumerable<ISqlDataParameter> parameters)
		{
			if (factory == null)
				throw new ArgumentNullException(nameof(factory));

			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			return _dataReaderProvider.ExecuteReaderForTypeCollection(factory, storedProcedureName, parameters);
		}

		public int ExecuteNonQuery(string storedProcedureName)
		{
			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));
			
			return _nonQueryDataProvider.Execute(storedProcedureName);
		}

		public int ExecuteNonQuery(string storedProcedureName, ISqlDataParameter parameter)
		{
			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException(nameof(parameter));

			return _nonQueryDataProvider.Execute(storedProcedureName, parameter);
		}

		public int ExecuteNonQuery(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters)
		{
			if (string.IsNullOrEmpty(storedProcedureName))
				throw new ArgumentNullException(nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			return _nonQueryDataProvider.Execute(storedProcedureName, parameters);
		}

		public ISqlDataParameter CreateParameter(string paramName, object value)
		{
			if (paramName == null)
				throw new ArgumentNullException(nameof(paramName));

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