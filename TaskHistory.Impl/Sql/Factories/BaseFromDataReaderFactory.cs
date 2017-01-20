using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	// TODO why do I have this?
	public abstract class BaseFromDataReaderFactory<T> : IFromDataReaderFactory<T>
	{
		public abstract T Build(ISqlDataReader reader);
	}
}