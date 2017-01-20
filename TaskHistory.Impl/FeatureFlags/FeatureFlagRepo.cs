using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.FeatureFlags
{
	public class FeatureFlagRepo : IFeatureFlagRepo
	{
		ApplicationDataProxy _dataProxy;
		FeatureFlagFactory _factory;

		const string CreateStoredProcedure = "FeatureFlags_Create";
		const string ReadStoredProcedure = "FeatureFlags_Read";
		const string UpdatedStoredProcedure = "FeatureFlags_Update";		
		const string DeleteStoredProcedure = "FeatureFlags_Delete";

		public IFeatureFlag Create(int userId, string name, string value)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(value));

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pName", name));
			parameters.Add(_dataProxy.CreateParameter("pValue", value));

			var returnVal = _dataProxy.Execute(_factory, 
			                                   CreateStoredProcedure, 
			                                   parameters);
			
			if (returnVal == null)
				throw new NullReferenceException("Null returned from DataProvider");

			return returnVal;
		}

		public IFeatureFlag Delete(int userId, int id)
		{
			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pId", id));

			var returnVal = _dataProxy.Execute(_factory,
											   DeleteStoredProcedure,
											   parameters);
			
			if (returnVal == null)
				throw new NullReferenceException("Null returned from DataProvider");

			return returnVal;
		}

		public IEnumerable<IFeatureFlag> Read(int userId)
		{
			var parameter = _dataProxy.CreateParameter("pUserId", userId);

			var returnVal = _dataProxy.ExecuteOnCollection(_factory,
											   DeleteStoredProcedure,
											   parameter);

			if (returnVal == null)
				throw new NullReferenceException("Null returned from DataProvider");

			return returnVal;
		}

		public IFeatureFlag Update(int userId, string name, string value)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(value));

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pUserId", userId));
			parameters.Add(_dataProxy.CreateParameter("pName", name));
			parameters.Add(_dataProxy.CreateParameter("pValue", value));

			var returnVal = _dataProxy.Execute(_factory,
			                                   UpdatedStoredProcedure,
											   parameters);

			if (returnVal == null)
				throw new NullReferenceException("Null returned from DataProvider");

			return returnVal;
		}

		public FeatureFlagRepo(FeatureFlagFactory factory,
		                       ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}
	}
}