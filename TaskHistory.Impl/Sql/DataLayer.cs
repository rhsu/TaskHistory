using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using TaskHistory.Api.Configuration;

namespace TaskHistory.Impl.Sql
{
	public class DataLayer : BaseDataLayer, IDataLayer
	{
		private readonly SqlDataReaderFactory _sqlDataReaderFactory;
		private readonly string _connectionString;

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			BaseDataLayer.CheckParameters<T> (factory, parameter, storedProcedureName);

			IEnumerable<T> collection = this.ExecuteReaderForTypeCollection<T> (factory, storedProcedureName, parameter);

			return collection.First ();
		}

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory, 
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			BaseDataLayer.CheckParameters<T> (factory, parameters, storedProcedureName);

			IEnumerable<T> collection = this.ExecuteReaderForTypeCollection<T> (factory, storedProcedureName, parameters);

			return collection.First ();
		}

		public IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			BaseDataLayer.CheckParameters (factory, parameter, storedProcedureName);

			return this.ExecuteReaderForTypeCollection<T> (factory, 
				storedProcedureName, 
				new List<ISqlDataParameter> { parameter });
		}

		public IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			BaseDataLayer.CheckParameters (factory, parameters, storedProcedureName);

			using (var connection = new MySqlConnection (_connectionString))
			using (var command = new MySqlCommand (storedProcedureName, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;

				foreach (var param in BaseDataLayer.CreateMySqlParametersFromSqlDataParams(parameters)) 
				{
					command.Parameters.Add (param);
				}

				command.Connection.Open ();

				MySqlDataReader reader = command.ExecuteReader (CommandBehavior.CloseConnection);
				ISqlDataReader sqlReader = _sqlDataReaderFactory.MakeDataReader(reader);

				var returnVal = new List<T> ();

				if (reader.Read ()) 
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

		public DataLayer (SqlDataReaderFactory sqlDataReaderFactory, IConfigurationProvider configurationProvider)
			: base()
		{
			_sqlDataReaderFactory = sqlDataReaderFactory;
			_connectionString = configurationProvider.SqlConnectionString;
		}
	}
}