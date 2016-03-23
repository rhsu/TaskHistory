using System;
using TaskHistoryImpl.MySql;

namespace TaskHistoryImpl
{
	public abstract class AbstractMySqlRepo
	{
		protected MySqlCommandFactory _mySqlCommandFactory;

		public AbstractMySqlRepo (MySqlCommandFactory mySqlCommandFactory)
		{
			_mySqlCommandFactory = mySqlCommandFactory;
		}
	}
}

