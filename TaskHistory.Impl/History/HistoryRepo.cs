using System;
using System.Collections.Generic;
using TaskHistory.Api.History;
using TaskHistory.Api.History.DataTransferObjects;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.History
{
	public class HistoryRepo : IHistoryRepo
	{
		const string ReadStoredProcedure = "";
		const string CreateStoredProcedure = "";

		ApplicationDataProxy _dataProxy;
		HistoryFactory _factory;

		public HistoryRepo(ApplicationDataProxy dataProxy, HistoryFactory factory)
		{
			_dataProxy = dataProxy;
			_factory = factory;
		}

		public IEnumerable<IHistory> Read(int userId)
		{
			var param = _dataProxy.CreateParameter("pUserId", userId);

			var retVal = _dataProxy.ExecuteOnCollection(_factory, CreateStoredProcedure);
			if (retVal == null)
				throw new NullReferenceException("Null returned from DataProxy");

			return retVal;
		}

		public IHistory Create(HistoryCreationParams historyDto)
		{
			if (historyDto == null)
				throw new ArgumentNullException(nameof(historyDto));

			throw new NotImplementedException();
		}

		List<ISqlDataParameter> ConvertParams(HistoryCreationParams dto)
		{
			if (dto == null)
				throw new ArgumentNullException(nameof(dto));

			var retVal = new List<ISqlDataParameter>();


			retVal.Add(_dataProxy.CreateParameter("pAction", dto.Action));
			retVal.Add(_dataProxy.CreateParameter("pObject", dto.Object));

			return retVal;
		}
	}
}
