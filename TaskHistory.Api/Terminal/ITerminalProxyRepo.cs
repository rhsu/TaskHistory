using System;
using System.Collections.Generic;
using TaskHistory.Api.Users;

namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProxyRepo
	{
		/// <summary>
		/// Performs the create operation.
		/// </summary>
		/// <returns>Number of Records Created</returns>
		/// <param name="commandOption">Command option.</param>
		/// <param name="registeredObject">Registered object.</param>
		/// <param name="user">User.</param>
		int PerformCreateOperation(TerminalCommandOption commandOption, 
			TerminalRegisteredObject registeredObject,
			IUser user);

		/// <summary>
		/// Performs the read operation.
		/// </summary>
		/// <returns>The read ITerminalObjects</returns>
		/// <param name="commandOption">Command option.</param>
		/// <param name="registeredObject">Registered object.</param>
		/// <param name="user">User.</param>
		IEnumerable<ITerminalObject> PerformReadOperation(TerminalCommandOption commandOption, 
			TerminalRegisteredObject registeredObject, 
			IUser user);

		/// <summary>
		/// Performs the update operation.
		/// </summary>
		/// <returns>Number of Records Created</returns>
		/// <param name="commandOption">Command option.</param>
		/// <param name="registeredObject">Registered object.</param>
		int PerformUpdateOperation (TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject);

		/// <summary>
		/// Performs the delete operation.
		/// </summary>
		/// <returns>Number of Records Created</returns>
		/// <param name="commandOption">Command option.</param>
		/// <param name="registeredObject">Registered object.</param>
		int PerformDeleteOperation (TerminalCommandOption commandOption, TerminalRegisteredObject registeredObject);
	}
}