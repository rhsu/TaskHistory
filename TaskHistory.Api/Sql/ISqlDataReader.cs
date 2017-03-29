using System;

namespace TaskHistory.Api.Sql
{
	public interface ISqlDataReader
	{
		bool Read();

		int GetInt(string propertyName);

		int? GetNullableInt(string propertyName);

		string GetString(string propertyName);

		bool GetBool(string propertyName);

		DateTime GetDateTime(string propertyName);
	}
}