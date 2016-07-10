using System;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Sql
{
	public abstract class BaseFromDataReaderFactory<T> : IFromDataReaderFactory<T>
	{
		public abstract T CreateTypeFromDataReader(ISqlDataReader reader);

		public BaseFromDataReaderFactory ()
		{
		}
	}
}

