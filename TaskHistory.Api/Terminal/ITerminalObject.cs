using System;

namespace TaskHistory.Api.Terminal
{
	/// <summary>
	/// An object that the Terminal Displays to the User
	/// </summary>
	public interface ITerminalObject
	{
		int ObjectId { get; }
		string ObjectName { get; }
	}
}