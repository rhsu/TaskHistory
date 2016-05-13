using TaskHistory.Impl.MySql;
using System;

namespace TaskHistory.Impl.MySql
{
	[Obsolete]
	public abstract class AbstractMySqlRepo
	{
		protected MySqlCommandFactory _mySqlCommandFactory;

		public AbstractMySqlRepo (MySqlCommandFactory mySqlCommandFactory)
		{
			_mySqlCommandFactory = mySqlCommandFactory;
		}
	}
}