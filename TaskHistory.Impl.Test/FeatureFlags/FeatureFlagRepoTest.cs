using System.Linq;
using NUnit.Framework;
using TaskHistory.Api.FeatureFlags;
using TaskHistory.Impl.FeatureFlags;
using TaskHistory.TestFramework;

namespace TaskHistory.Impl.Test.FeatureFlags
{
	[TestFixture]
	public class FeatureFlagRepoTest
	{
		IFeatureFlagRepo _repo;

		[SetUp]
		public void Init()
		{
			var factory = new FeatureFlagFactory();
			var dataProxy = new ApplicationDataProxyFactory().Build();

			_repo = new FeatureFlagRepo(factory, dataProxy);
		}

		[Test]
		public void Create()
		{
			var name = "Feature Flag Name";
			var value = "this is a value";
			IFeatureFlag feature = _repo.Create(name,
												value);

			Assert.AreEqual(name, feature.Name);
			Assert.AreEqual(value, feature.Value);	                                    
		}

		[Test]
		public void Read()
		{
			_repo.DeleteAll();

			for (var i = 0; i < 5; i++)
			{
				_repo.Create($"name{i}", $"value{i}");
			}

			var flags = _repo.Read().ToList();

			for (var i = 0; i < 5; i++)
			{
				var exists = flags.Exists(x => x.Name == $"name{i}");
				Assert.True(exists);
			}
		}

		[Test]
		public void Delete()
		{
			var name = "Feature Flag Name";
			var value = "this is a value";

			IFeatureFlag flag = _repo.Create(name,
												value);

			var flags = _repo.Read().ToList();

			Assert.True(flags.Exists(x => x.Id == flag.Id));

			int numDeleted = _repo.Delete(flag.Id);

			Assert.AreEqual(1, numDeleted);
		}

		[Test]
		public void DeleteAll()
		{
			for (var i = 0; i < 5; i++)
			{
				_repo.Create("name", "value");	
			}

			_repo.DeleteAll();

			var flags = _repo.Read();
			Assert.True(flags.Count() == 0);
		}
	}
}
