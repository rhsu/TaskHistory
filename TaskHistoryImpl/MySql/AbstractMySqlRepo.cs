using TaskHistory.Impl.MySql;

namespace TaskHistory.Impl.MySql
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