namespace TaskHistory.Api.Users
{
	public interface IDefaultUserProvider
	{
		bool DefaultUserExists();

		IUser RegisterDefaultUser();
	}
}
