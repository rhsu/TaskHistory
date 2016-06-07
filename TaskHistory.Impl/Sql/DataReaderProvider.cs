using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using TaskHistory.Api.Configuration;

namespace TaskHistory.Impl.Sql
{
	/// <summary>
	/// Provider that communicates with a my sql database for reading data 
	/// Consider using ApplicationDataProxy instead of using this class directly
	/// </summary>
	public class DataReaderProvider : BaseDataProvider, IDataReaderProvider
	{
		private readonly SqlDataReaderFactory _sqlDataReaderFactory;
		private readonly string _connectionString;

		private const string NullFromExecuteReaderForTypeCollection = "Null returned from ExceuteReaderForTypeCollection";

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if ((storedProcedureName == null) || (storedProcedureName == string.Empty))
				throw new ArgumentNullException ("storedProcedureName");

			if (parameter == null)
				throw new ArgumentNullException ("parameter");

			IEnumerable<T> collection = this.ExecuteReaderForTypeCollection<T> (factory, storedProcedureName, parameter);
			if (collection == null)
				throw new NullReferenceException (NullFromExecuteReaderForTypeCollection);

			return collection.First ();
		}

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory, 
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if ((storedProcedureName == null) || (storedProcedureName == string.Empty))
				throw new ArgumentNullException ("storedProcedureName");

			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			IEnumerable<T> collection = this.ExecuteReaderForTypeCollection<T> (factory, storedProcedureName, parameters);
			if (collection == null)
				throw new NullReferenceException (NullFromExecuteReaderForTypeCollection);

			return collection.First ();
		}

		public IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if ((storedProcedureName == null) || (storedProcedureName == string.Empty))
				throw new ArgumentNullException ("storedProcedureName");

			if (parameter == null)
				throw new ArgumentNullException ("parameter");

			var returnVal = ExecuteReaderForTypeCollection<T> (factory, 
				storedProcedureName, 
				new List<ISqlDataParameter> { parameter });

			if (returnVal == null)
				throw new NullReferenceException (NullFromExecuteReaderForTypeCollection);

			return returnVal;
		}

		public IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if ((storedProcedureName == null) || (storedProcedureName == string.Empty))
				throw new ArgumentNullException ("storedProcedureName");

			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			using (var connection = new MySqlConnection (_connectionString))
			using (var command = new MySqlCommand (storedProcedureName, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;

				var dataProviderParameters = BaseDataProvider.CreateMySqlParametersFromSqlDataParams (parameters);
				if (dataProviderParameters == null)
					throw new NullReferenceException ("Null returned from CreateMySqlParametersFromSqlDataParams in base class");

				foreach (var param in dataProviderParameters) 
				{
					command.Parameters.Add (param);
				}

				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);
				ISqlDataReader sqlReader = _sqlDataReaderFactory.MakeDataReader(reader);
				if (sqlReader == null)
					throw new NullReferenceException ("Null returned from SqlDataReaderFactory");

				var returnVal = new List<T> ();

				while (reader.Read ()) 
				{
					T currentItem = factory.CreateTypeFromDataReader (sqlReader);
					returnVal.Add (currentItem);
				}
				return returnVal;
			}
		}

		public void ExecuteNonQuery()
		{
		}

		public DataReaderProvider (SqlDataReaderFactory sqlDataReaderFactory, IConfigurationProvider configurationProvider)
			: base()
		{
			_sqlDataReaderFactory = sqlDataReaderFactory;
			_connectionString = configurationProvider.SqlConnectionString;
		}
	}
}