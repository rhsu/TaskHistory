using System;
using TaskHistory.Api.Users;
using TaskHistory.Api.Terminal;
using System.Collections.Generic;

namespace TaskHistory.Impl.Terminal
{
	public class TerminalProxyRepo : ITerminalProxyRepo
	{
		readonly IRegisteredObjectRepoProxy _registeredObjProxy;
		private readonly ITerminalObjectMapper _terminalObjectMapper;

		public ITerminalObjectMapper TerminalObjectMapper
		{
			get
			{
				return _terminalObjectMapper;
			}
		}

		// TODO Register the repos with an attribute
		// DetermineRepoToUse() function

		// TODO IUser should come from a context object
		public int PerformCreateOperation(TerminalCommandResponse commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (commandResponse.CommandAction != TerminalCommandAction.Insert)
				throw new InvalidOperationException($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			switch (commandResponse.RegisteredObject)
			{
				case TerminalRegisteredObject.Label:
					_registeredObjProxy.LabelRepo.CreateNewLabel("some content from command response's option");
					break;
				case TerminalRegisteredObject.Task:
					_registeredObjProxy.TaskRepo.CreateTask("some content from command response's object",
					                                       user.UserId);
					break;
			}

			return 1;
		}

		public IEnumerable<ITerminalObject> PerformReadOperation(TerminalCommandResponse commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (commandResponse.CommandAction != TerminalCommandAction.List)
				throw new InvalidOperationException($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			var returnVal = new List<ITerminalObject>();

			//TODO refactor this switch statement into a function which transforms an enum + IUser into a collection of ITerminalObjects
			switch (commandResponse.RegisteredObject)
			{
				case TerminalRegisteredObject.Label:
					var labels = _registeredObjProxy.LabelRepo.ReadAllLabelsForUser(user);
					var labelTerminalObjects = TerminalObjectMapper.ConvertLabels(labels);
					returnVal.AddRange(labelTerminalObjects);
					//TODO consider adding in an attribute onto Label to denote that field x is the Id and field y is the Value
					//TODO should that attribute be on ILabel or Label?

					break;
				case TerminalRegisteredObject.Task:
					var tasks = _registeredObjProxy.TaskRepo.ReadTasks(user.UserId);
					var taskTerminalObjects = TerminalObjectMapper.ConvertTasks(tasks);
					returnVal.AddRange(taskTerminalObjects);

					break;
			}

			return returnVal;
		}

		public int PerformUpdateOperation(TerminalCommandResponse commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			if (commandResponse.CommandAction != TerminalCommandAction.Update)
				throw new InvalidOperationException($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			switch (commandResponse.RegisteredObject)
			{
				case TerminalRegisteredObject.Label:
					// Need to create a label from commandReponse's 
					_registeredObjProxy.LabelRepo.UpdateLabel(null);
					break;
				case TerminalRegisteredObject.Task:
					// need to create task updating parameters
					_registeredObjProxy.TaskRepo.UpdateTask(null, user.UserId);
					break;
			}

			return -1;
		}

		public int PerformDeleteOperation(TerminalCommandResponse commandResponse, IUser user)
		{
			if (user == null)
				throw new ArgumentNullException("user");

			if (commandResponse.CommandAction != TerminalCommandAction.Delete)
				throw new InvalidOperationException($"Command action for this operation must be list instead of {commandResponse.CommandAction}");

			return -1;
		}

		public TerminalProxyRepo(IRegisteredObjectRepoProxy objProxy, ITerminalObjectMapper objMapper)
		{
			_registeredObjProxy = objProxy;
			_terminalObjectMapper = objMapper;
		}
	}
}