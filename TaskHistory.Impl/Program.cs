using Ninject;
using System;
using Ninject.Parameters;

namespace TaskHistoryTestBench
{
	public interface IDepA
	{
		int GetInt { get; }
	}

	public interface IDepB
	{
		string GetString { get; }
	}

	public class DepA : IDepA
	{
		public int GetInt => 5;
	}

	public class DepB : IDepB
	{
		public string GetString => "Hello";
	}

	public interface IThing
	{
		string Display { get; }
	}

	public class Thing : IThing
	{
		private IDepA _a;
		private IDepB _b;
		private string _c;

		public string Display
		{
			get 
			{
				return string.Format ("{0} {1} {2}", _a.GetInt, _b.GetString, _c);
			}
		}

		public Thing(IDepA a, IDepB b, string c)
		{
			_a = a;
			_b = b;
			_c = c;
		}
	}

	public class MainClass
	{
		public static void Main (string[] args)
		{
			IKernel kernel = new StandardKernel ();

			kernel.Bind<IDepA> ().To<DepA> ();
			kernel.Bind<IDepB> ().To<DepB> ();
			kernel.Bind<IThing> ().To<Thing> ();

			IThing newThing = kernel.Get<IThing> (new ConstructorArgument("c", "asdf"));

			Console.Out.WriteLine (newThing.Display);

			kernel.Dispose ();
		}
	}
}