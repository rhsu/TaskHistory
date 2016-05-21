using System;
using TaskHistory.Api.Sql;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Linq;

namespace TaskHistory.Impl.Sql
{
	public class DataLayer : IDataLayer
	{
		private SqlDataReaderFactory _sqlDataReaderFactory;

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			CheckParameters<T> (factory, storedProcedureName, parameter);

			IEnumerable<T> collection = this.ExecuteReaderForTypeCollection<T> (factory, storedProcedureName, parameter);

			return collection.First ();
		}

		public T ExecuteReaderForSingleType<T> (IFromDataReaderFactory<T> factory, 
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			CheckParameters<T> (factory, storedProcedureName, parameters);

			IEnumerable<T> collection = this.ExecuteReaderForTypeCollection<T> (factory, storedProcedureName, parameters);

			return collection.First ();
		}

		public IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			ISqlDataParameter parameter)
		{
			CheckParameters (factory, storedProcedureName, parameter);

			this.ExecuteReaderForTypeCollection<T> (factory, storedProcedureName, new List<ISqlDataParameter> { parameter });
		}

		IEnumerable<T> ExecuteReaderForTypeCollection<T> (IFromDataReaderFactory<T> factory,
			string storedProcedureName,
			IEnumerable<ISqlDataParameter> parameters)
		{
			CheckParameters (factory, storedProcedureName, parameters);

			using (var connection = new MySqlConnection (ConfigurationManager.AppSettings ["MySqlConnection"]))
			using (var command = new MySqlCommand (storedProcedureName, connection)) 
			{
				command.CommandType = CommandType.StoredProcedure;

				foreach (var param in CreateMySqlParametersFromSqlDataParams(parameters)) 
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

		private static List<MySqlParameter> CreateMySqlParametersFromSqlDataParams(IEnumerable<ISqlDataParameter> parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			var returnVal = new List<MySqlParameter> ();

			foreach (var p in parameters) 
			{
				returnVal.Add(CreateSqlParameterFromSqlDataParams(p));
			}

			return returnVal;
		}

		private static MySqlParameter CreateSqlParameterFromSqlDataParams(ISqlDataParameter parameters)
		{
			return new MySqlParameter (parameters.ParamName, parameters.Value);
		}

		private static void CheckParameters<T>(IFromDataReaderFactory<T> factory, IEnumerable<ISqlDataParameter> parameters, string storedProcedureName)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			if (storedProcedureName == string.Empty || storedProcedureName == null)
				throw new ArgumentNullException ("storedProcedureName");
		}

		private static void CheckParameters<T>(IFromDataReaderFactory<T> factory, ISqlDataParameter parameter, string storedProcedureName)
		{
			if (factory == null)
				throw new ArgumentNullException ("factory");

			if (parameter == null)
				throw new ArgumentNullException ("parameters");

			if (storedProcedureName == string.Empty || storedProcedureName == null)
				throw new ArgumentNullException ("storedProcedureName");
		}

		public void ExecuteNonQuery()
		{
		}

		public DataLayer (SqlDataReaderFactory sqlDataReaderFactory)
		{
			_sqlDataReaderFactory = sqlDataReaderFactory;
		}
	}
}

