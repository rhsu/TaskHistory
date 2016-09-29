﻿using System;
using Ninject;
using TaskHistory.Api.ViewRepos;
using TaskHistory.Impl.ViewRepos;

namespace TaskHistory.Bindings
{
	public class ViewRepoModule : IModule
	{
		public void Bind(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException(nameof(kernel));

			kernel.Bind<ITaskViewRepo>()
				  .To<TaskViewRepo>();
		}
	}
}