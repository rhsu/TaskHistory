using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.Shared
{
	public abstract class BaseRepo
	{
		protected const string NullFromApplicationDataProxy = "Null returned from DataProvider";

		protected ApplicationDataProxy _dataProxy;

		public BaseRepo(ApplicationDataProxy dataProxy)
		{
			_dataProxy = dataProxy;
		}
	}
}
