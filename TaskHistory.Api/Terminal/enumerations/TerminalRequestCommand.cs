namespace TaskHistory.Api.Terminal
{
	public enum TerminalRequestCommand
	{
		/// <summary>
		/// List Command
		/// </summary>
		LIST,

		/// <summary>
		/// Update Command
		/// </summary>
		UPDATE,

		/// <summary>
		/// Delete Command
		/// </summary>
		DELETE,

		/// <summary>
		/// Insert Command
		/// </summary>
		INSERT,

		/// <summary>
		/// Denotes an error command
		/// </summary>
		ERROR
	}
}