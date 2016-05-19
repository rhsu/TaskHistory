using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.MySql
{
	public class DataParameterFactory
	{
		public ISqlDataParameter CreateDataParemeter(string name, object value)
		{
			return new DataParameter (name, value);
		}

		public DataParameterFactory ()
		{
			
		}
	}
}

