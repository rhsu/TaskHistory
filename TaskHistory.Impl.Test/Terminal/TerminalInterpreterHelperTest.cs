using System;
using NUnit.Framework;
using TaskHistory.Api.Terminal;
using TaskHistory.Impl.Terminal;

namespace TaskHistory.Impl.Test
{
	[TestFixture]
	public class TerminalInterpreterHelperTest
	{
		[Test]
		public void DetermineTerminalRegisteredObject_Test()
		{
			var result = TerminalInterpreterHelper.DetermineTerminalRegisteredObject("TASK");

			Assert.AreEqual(TerminalRegisteredObject.Task, result);
		}
	}
}
