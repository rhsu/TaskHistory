using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace TaskHistoryImpl
{
	public class MySqlCommandFactory
	{
		private static MySqlConnection _mySqlConnection = new MySqlConnection(ConfigurationManager.AppSettings["MySqlConnection"]);

		internal MySqlCommand CreateMySqlCommand(string procedureName)
		{
			var returnVal = new MySqlCommand(procedureName, _mySqlConnection);
			returnVal.CommandType = CommandType.StoredProcedure;

			return returnVal;
		}

		public MySqlCommandFactory ()
		{
		}
	}
}