using System;
using TaskHistory.Api.History;

namespace TaskHistory.Impl.History
{
	public class History : IHistory
	{
		readonly BusinessAction _action;
		readonly DateTime _actionDate;
		readonly int _id;
		readonly BusinessObject _obj;
		readonly int _userId;

		public BusinessAction Action
		{
			get { return _action; }
		}

		public DateTime ActionDate
		{
			get { return _actionDate; }
		}

		public int Id
		{
			get { return _id; }
		}

		public BusinessObject Object
		{
			get { return _obj; }
		}

		public int UserId
		{
			get { return _userId; }
		}

		public History(int id,
					   BusinessAction action,
					   BusinessObject obj,
					   DateTime actionDate,
					   int userId)
		{
			_id = id;
			_action = action;
			_obj = obj;
			_actionDate = actionDate;
			_userId = userId;
		}
	}
}
