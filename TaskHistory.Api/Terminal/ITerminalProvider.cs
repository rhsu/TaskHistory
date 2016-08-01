namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProvider
	{
		TerminalCommandRequest ProcessCommand (string requestCommand);
	}
}