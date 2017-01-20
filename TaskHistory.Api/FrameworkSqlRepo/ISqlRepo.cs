using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.FrameworkSqlRepo
{
	public interface ICreateParams<T>
	{
	}

	public interface IUpdateParams<T>
	{
	}

	public interface ISqlRepo<T>
	{
		// TODO What if I did parameters by reflection
		//      for FeatureFlag repo. Pass in the featureFlag object 
		//      parse the properties on the object as parameters
		//      send to the database
		T Create(int userId, int id, object parameters);

		IEnumerable<T> Read(IUser user);

		T Update(int userId, int id, object parmeters);

		T Delete(int userId, int id);
	}

	public abstract class BaseSqlRepo<T> : ISqlRepo<T>
	{
		public T Create(int userId, int id, object parameters)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> Read(IUser user)
		{
			throw new NotImplementedException();
		}

		public T Update(int userId, int id, object parmeters)
		{
			throw new NotImplementedException();
		}

		public T Delete(int userId, int id)
		{
			throw new NotImplementedException();
		}
	}
}