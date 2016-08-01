using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Api.Terminal;

namespace TaskHistory.Impl.Terminal
{
	public class ITerminalProxyRepo
	{
		private ITaskRepo _taskRepo;
		private IUserRepo _userRepo;

		public void PerformActionForResponse(TerminalCommandResponse commandResponse)
		{
			if (commandResponse == null)
				throw new ArgumentNullException ("commandResponse");

			switch (commandResponse.TerminalRequest) 
			{

			/*case TerminalCommandAction.Delete:
			case TerminalCommandAction.Delete:
			case TerminalCommandAction.Delete:			
			case TerminalCommandAction.Delete:*/
			}
		}

		public ITerminalProxyRepo (ITaskRepo taskRepo, IUserRepo userRepo)
		{
			_taskRepo = taskRepo;
			_userRepo = userRepo;
		}
	}
}