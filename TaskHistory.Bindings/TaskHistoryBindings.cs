using Ninject;
using System.Collections.Generic;
using System;

namespace TaskHistory.Bindings
{
	public class TaskHistoryBindings
	{
		static TaskHistoryBindings _bindings;
		readonly List<IModule> _allModules;

		public static TaskHistoryBindings GetInstance()
		{
			if (_bindings == null)
				_bindings = new TaskHistoryBindings ();
			
			return _bindings;
		}

		public TaskHistoryBindings ()
		{
			_allModules = new List<IModule>();
			SetupAllModules ();
		}

		private void SetupAllModules()
		{
			_allModules.Add (new ConfigurationModule ());
			_allModules.Add (new SqlModule ());
			_allModules.Add (new TaskModule ());
			_allModules.Add (new UserModule ());
			_allModules.Add (new ViewRepoModule ());
			_allModules.Add (new TerminalModule());
			_allModules.Add (new LabelModule());
			_allModules.Add (new FeatureFlagModule());
			_allModules.Add (new TaskListsModule());
		}

		public void DoAllBindings(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException (nameof(kernel));

			foreach (var module in _allModules) 
			{
				module.Bind (kernel);
			}
		}
	}
}

