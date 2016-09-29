using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Configuration;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	/// <summary>
	/// Provider that communicates with a mysql database for nonqueries
	/// Consider using ApplicationDataProxy instead of using this class directly
	/// </summary>
	public class NonQueryDataProvider : BaseDataProvider, INonQueryDataProvider
	{
		private readonly IConfigurationProvider _configurationProvider;

		public void ExecuteNonQuery (string storedProcedureName)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException (nameof(storedProcedureName));

			this.ExecuteNonQuery(storedProcedureName, new List<ISqlDataParameter>());
		}

		public void ExecuteNonQuery(string storedProcedureName, ISqlDataParameter parameter)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException (nameof(storedProcedureName));

			if (parameter == null)
				throw new ArgumentNullException (nameof(parameter));

			this.ExecuteNonQuery (storedProcedureName, new List<ISqlDataParameter> { parameter });
		}

		public void ExecuteNonQuery(string storedProcedureName, IEnumerable<ISqlDataParameter> parameters)
		{
			if (storedProcedureName == null || storedProcedureName == string.Empty)
				throw new ArgumentNullException (nameof(storedProcedureName));

			if (parameters == null)
				throw new ArgumentNullException ("parameters");

			using (var connection = new MySqlConnection (_configurationProvider.SqlConnectionString))
			using (var command = new MySqlCommand (storedProcedureName)) 
			{
				command.CommandType = CommandType.StoredProcedure;

				var mySqlParams = BaseDataProvider.CreateMySqlParametersFromSqlDataParams (parameters);

				if (mySqlParams == null)
					throw new NullReferenceException ("Null returned from CreateMySqlParametersFromSqlDataParams in base class");

				foreach (var p in mySqlParams) 
				{
					command.Parameters.Add (p);
				}

				command.Connection.Open ();
				command.ExecuteNonQuery ();
			}
		}

		public NonQueryDataProvider (IConfigurationProvider configurationProvider) :
			base()
		{
			_configurationProvider = configurationProvider;
		}
	}
}