﻿using System;

namespace TaskHistoryApi.Users
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

		IUser RegisterUser (string username, string password, string firstName, string lastName, string email);
	}
}
