using System;
using TaskHistory.Api.History;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.History
{
	public class HistoryFactory : IFromDataReaderFactory<IHistory>
	{
		public IHistory Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));

			int id = reader.GetInt("historyId");
			int userId = reader.GetInt("userId");

			DateTime actionDate = reader.GetDateTime("actionDate");

			BusinessAction businessAction = reader.GetEnum<BusinessAction>("BusinessAction");
			BusinessObject businessObject = reader.GetEnum<BusinessObject>("BusinessObject");

			var retVal = new History(id, businessAction, businessObject, actionDate, userId);
			return retVal;
		}
	}
}