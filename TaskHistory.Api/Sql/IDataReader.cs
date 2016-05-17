using System;

namespace TaskHistory.Api.Sql
{
	public interface IDataReader
	{
		bool Read();

		int GetInt(string propertyName);

		string GetString(string propertyName);

		int GetBool(string propertyName);
	}
}