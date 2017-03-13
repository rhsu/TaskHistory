namespace TaskHistory.Api.Users
{
	public interface IAdminUserProvider
	{
		IUser AuthenticateAdminUser(string name, string password);
	}
}
