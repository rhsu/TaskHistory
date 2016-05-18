using System;
using MySql.Data.MySqlClient;
using TaskHistory.Api.Sql;
using System.Collections.Generic;

namespace TaskHistory.Impl.MySql
{
	public class DataParameterCollectionFactory
	{
		public IEnumerable<DataParameter> CreateDataParameterCollection(IEnumerable<MySqlParameter> mySqlParameters)
		{
			if (mySqlParameters == null)
				throw new ArgumentNullException ("mySqlParameters");

			var returnVal = new List<DataParameter> ();

			foreach (var param in mySqlParameters) 
			{
				returnVal.Add (new DataParameter (param));
			}

			return returnVal;
		}

		public DataParameterCollectionFactory() 
		{
		}
	}

	public class DataParameter : IDataParameter<MySqlParameter>
	{
		private MySqlParameter _sqlParameter;

		public MySqlParameter GetParameter()
		{
			return _sqlParameter;
		}

		public DataParameter (MySqlParameter sqlParameter)
		{
			_sqlParameter = sqlParameter;
		}
	}
}