namespace TaskHistory.Api.Terminal
{
	public interface ITerminalProvider
	{
		TerminalCommandResponse InterpretStringCommand (string requestCommand);
	}
}