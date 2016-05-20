using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
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

