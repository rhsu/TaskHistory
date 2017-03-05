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

		public IFeatureFlag Create(string name, string value)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(value));

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pName", name));
			parameters.Add(_dataProxy.CreateParameter("pValue", value));

			var returnVal = _dataProxy.ExecuteReader(_factory, 
			                                   CreateStoredProcedure, 
			                                   parameters);
			
			if (returnVal == null)
				throw new NullReferenceException("Null returned from DataProvider");

			return returnVal;
		}

		public IEnumerable<IFeatureFlag> ReadAll()
		{
			var returnVal = _dataProxy.ExecuteOnCollection(_factory,
														   ReadStoredProcedure);

			if (returnVal == null)
				throw new NullReferenceException("Null returned from DataProvider");

			return returnVal;
		}

		public IFeatureFlag Read(string key)
		{
			// TODO: given a key 
			// SELECT * FROM FeatureFlags
			//   WHERE key = pKey

			// TODO: Flags may also be on a per user basis
			// 	in that case, may need another FeatureFlagToUser table
			// and this function will need to take in a UserId

			throw new NotImplementedException("Not implemented yet");
		}

		// TODO No way to actually test this yet
		public int Delete(int id)
		{
			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pId", id));

			return _dataProxy.ExecuteNonQuery(DeleteStoredProcedure,
											  parameters);
		}

		public IFeatureFlag Update(int id, string name, string value)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException(nameof(value));

			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pName", name));
			parameters.Add(_dataProxy.CreateParameter("pValue", value));
			parameters.Add(_dataProxy.CreateParameter("pId", id));

			var returnVal = _dataProxy.ExecuteReader(_factory,
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