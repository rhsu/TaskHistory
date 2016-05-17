using System;

namespace TaskHistory.Api.Sql
{
	public interface IFromDataReaderFactory<T>
	{
		T CreateTypeFromDataReader(ISqlDataReader reader);
	}
}