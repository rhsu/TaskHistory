namespace TaskHistory.Api.Terminal
{
	public struct TerminalCommandResponse
	{
		public TerminalCommandAction CommandAction { get; }
		public TerminalRegisteredObject RegisteredObject { get; }
		public string CommandOptions { get; }

		public TerminalCommandResponse(TerminalCommandAction action,
			TerminalRegisteredObject registeredObj,
			string opt)
		{
			CommandAction = action;
			RegisteredObject = registeredObj;
			CommandOptions = opt;
		}
	}
}