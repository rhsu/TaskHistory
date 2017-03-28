using System;
using TaskHistory.Api;
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
			get
			{
				throw new NotImplementedException();
			}
		}

		public int Id
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public BusinessObject Object
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public int UserId
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
