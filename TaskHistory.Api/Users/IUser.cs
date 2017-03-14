namespace TaskHistory.Api.Users
{
	public interface IUser
	{
		int Id { get; }
		string Username { get; }
		string FirstName { get; }
		string LastName { get; }
		// TODO: what does FullName do and do I absolutely need it?
		string FullName { get; }
		string Email { get; }
	}
}