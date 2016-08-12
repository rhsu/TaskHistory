using System;
using TaskHistory.Api.Tasks;
using TaskHistory.Api.Users;
using TaskHistory.Api.Terminal;
using System.Collections.Generic;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalProxyRepo : ITerminalProxyRepo
	{
		private ITaskRepo _taskRepo;
		private IUserRepo _userRepo;

		public void PerformActionForResponse(TerminalCommandResponse commandResponse)
		{
			if (commandResponse == null)
				throw new ArgumentNullException ("commandResponse");

			//switch (commandResponse.TerminalRequest) 
			//{

			/*case TerminalCommandAction.Delete:
			case TerminalCommandAction.Delete:
			case TerminalCommandAction.Delete:			
			case TerminalCommandAction.Delete:*/
			//}
		}

		public IEnumerable<ITerminalObject> ReadTerminalObjects()
		{
			return null;
		}

		public TerminalProxyRepo (ITaskRepo taskRepo, IUserRepo userRepo)
		{
			_taskRepo = taskRepo;
			_userRepo = userRepo;
		}
	}
}