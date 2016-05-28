using Ninject;

namespace TaskHistory.Bindings
{
	public interface IModule
	{
		void Bind(IKernel kernel);
	}
}