using System;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.FeatureFlags
{
	public class FeatureFlagFactory : IFromDataReaderFactory<IFeatureFlag>
	{
		public IFeatureFlag Build(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException(nameof(reader));

			var id = reader.GetInt("Id");
			var name = reader.GetString("Name");
			var value = reader.GetString("Value");

			return new FeatureFlag(id, name, value);
		}
	}
}
