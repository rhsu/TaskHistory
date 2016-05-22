using Ninject;
using System.Collections.Generic;
using System;

namespace TaskHistory.Bindings
{
	public class TaskHistoryBindings
	{
		private static TaskHistoryBindings _bindings;
		private readonly List<IModule> _allModules;

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
		}

		public void DoAllBindings(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException ("kernel");

			foreach (var module in _allModules) 
			{
				module.Bind (kernel);
			}
		}
	}
}

