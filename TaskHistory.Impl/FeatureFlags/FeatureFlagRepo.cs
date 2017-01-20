using System;
using System.Collections.Generic;
using TaskHistory.Api.FeatureFlags;
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

		public IFeatureFlag Create()
		{
			
			throw new NotImplementedException();
		}

		public IFeatureFlag Delete()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IFeatureFlag> Read()
		{
			throw new NotImplementedException();
		}

		public IFeatureFlag Update()
		{
			throw new NotImplementedException();
		}

		public FeatureFlagRepo(FeatureFlagFactory factory,
		                       ApplicationDataProxy dataProxy)
		{
			_factory = factory;
			_dataProxy = dataProxy;
		}
	}
}