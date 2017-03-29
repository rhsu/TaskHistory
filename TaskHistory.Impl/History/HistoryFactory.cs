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

			// TODO Make a get enum method
			// so I can do string action = reader.GetEnum<BusinessAction>("businessAction");
			// string action = reader.GetString("businessAction");
			// string obj = reader.GetString("businessObject");

			// TODO how?
			DateTime actionDate = reader.GetDateTime("actionDate");

			BusinessAction tempAction = BusinessAction.Create;
			BusinessObject tempObject = BusinessObject.Task;

			var retVal = new History(id, tempAction, tempObject, actionDate, userId);
			return retVal;
		}
	}
}