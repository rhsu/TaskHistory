using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl
{
	public abstract class BaseRepo<T>
	{
		protected ApplicationDataProxy _dataProxy;

		public BaseRepo(IFromDataReaderFactory<T> sqlDataReaderFactory, ApplicationDataProxy dataProxy)
		{
			_dataProxy = dataProxy;
		}
	}
}
