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
		const string CreateStoredProcedure = "History_Create";
		const string ReadStoredProcedure = "History_Select";

		HistoryFactory _factory;
		ApplicationDataProxy _dataProxy;

		public HistoryRepo(HistoryFactory factory, ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}

		public IHistory Create(int userId, HistoryCreationParams historyDto)
		{
			if (historyDto == null)
				throw new ArgumentNullException(nameof(historyDto));

			var parameters = BuildParameters(userId, historyDto);
			if (parameters == null)
				throw new NullReferenceException("null returned from Repo");

			var retVal = _dataProxy.ExecuteReader(_factory,
												  CreateStoredProcedure,
												  parameters);
			if (retVal == null)
				throw new NullReferenceException("null returned from DataProxy");

			return retVal;
		}

		public IEnumerable<IHistory> Read(int userId)
		{
			var param = _dataProxy.CreateParameter("pUserId", userId);

			var retVal = _dataProxy.ExecuteOnCollection(_factory, 
			                                            ReadStoredProcedure, 
			                                            param);
			if (retVal == null)
				throw new NullReferenceException("Null returned from DataProxy");

			return retVal;
		}

		List<ISqlDataParameter> BuildParameters(int userId, HistoryCreationParams dto)
		{
			if (dto == null)
				throw new ArgumentNullException(nameof(dto));

			var retVal = new List<ISqlDataParameter>();

			retVal.Add(_dataProxy.CreateParameter("pAction", dto.Action));
			retVal.Add(_dataProxy.CreateParameter("pObject", dto.Object));
			retVal.Add(_dataProxy.CreateParameter("pUserId", userId));

			return retVal;
		}
	}
}
