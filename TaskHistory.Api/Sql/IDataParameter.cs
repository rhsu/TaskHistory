using System;

namespace TaskHistory.Api.Sql
{
	public interface IDataParameter<TSqlDataParameter>
	{
		TSqlDataParameter GetParameter();
	}
}