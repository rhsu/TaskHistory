using System;
using TaskHistory.Api.Users;
using TaskHistory.Impl.Sql;
using TaskHistory.Api.Sql;

namespace TaskHistory.Impl.Users
{
	public class UserFactory : BaseFromDataReaderFactory<IUser>
	{
		public UserFactory ()
			: base()
		{
		}

		public override IUser CreateTypeFromDataReader(ISqlDataReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");

			int userId = reader.GetInt ("userId");
			string userName = reader.GetString ("userName");
			string firstName = reader.GetString ("firstName");
			string lastName = reader.GetString ("lastName");
			string email = reader.GetString ("email");

			return new User (userId, userName, firstName, lastName, email);
		}
	}
}