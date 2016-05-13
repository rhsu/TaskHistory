using System;

namespace TaskHistory.Api.Users
{
	public interface IUserRepo
	{
		/// <summary>
		/// Validates the username and password.
		/// </summary>
		/// <returns>An IUser object is successful. Otherwise null</returns>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		IUser ValidateUsernameAndPassword (string username, string password);

		/// <summary>
		/// Registers the user.
		/// </summary>
		/// <returns>The user.</returns>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		/// <param name="firstName">First name.</param>
		/// <param name="lastName">Last name.</param>
		/// <param name="email">Email.</param>
		IUser RegisterUser (string username, string password, string firstName, string lastName, string email);
	}
}