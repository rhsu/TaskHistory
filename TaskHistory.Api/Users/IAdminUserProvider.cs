namespace TaskHistory.Api.Users
{
	public interface IAdminUserProvider
	{
		IUser AuthenticateAdminUser(string name, string password);

		// TODO Should I make a DefaultUserProvider?
		bool DefaultUserExists();

		IUser RegisterDefaultUser();
	}
}
