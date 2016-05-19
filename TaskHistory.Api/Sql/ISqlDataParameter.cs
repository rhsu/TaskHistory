using System;

namespace TaskHistory.Api.Sql
{
	public interface ISqlDataParameter
	{
		string ParameterName { get; }

		object Value { get; }
	}
}