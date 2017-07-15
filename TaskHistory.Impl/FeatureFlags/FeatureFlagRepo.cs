using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Api.Sql;
using TaskHistory.Impl.Shared;
using TaskHistory.Impl.Sql;

namespace TaskHistory.Impl.FeatureFlags
{
	public class FeatureFlagRepo : BaseRepo, IFeatureFlagRepo
	{
		FeatureFlagFactory _factory;

		const string CreateStoredProcedure = "FeatureFlags_Create";
		const string ReadStoredProcedure = "FeatureFlags_Read";
		const string UpdatedStoredProcedure = "FeatureFlags_Update";		
		const string DeleteStoredProcedure = "FeatureFlags_Delete";
		const string DeleteAllStoredProcedure = "FeatureFlags_All_Delete";

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
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public int Delete(int id)
		{
			var parameters = new List<ISqlDataParameter>();

			parameters.Add(_dataProxy.CreateParameter("pId", id));

			// TODO is there a unit test which checks the return value of this?
			return _dataProxy.ExecuteNonQuery(DeleteStoredProcedure, parameters);
		}

		public IEnumerable<IFeatureFlag> Read()
		{
			var returnVal = _dataProxy.ExecuteOnCollection(_factory,
														   ReadStoredProcedure);

			if (returnVal == null)
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
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
				throw new NullReferenceException(NullFromApplicationDataProxy);

			return returnVal;
		}

		public int DeleteAll()
		{
			int deleted = _dataProxy.ExecuteNonQuery(DeleteAllStoredProcedure);
			return deleted;
		}

		public FeatureFlagRepo(FeatureFlagFactory factory,
							   ApplicationDataProxy dataProxy)
			: base(dataProxy)
		{
			_factory = factory;
		}
	}
}