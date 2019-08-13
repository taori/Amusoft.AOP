using System.Reflection;

namespace Amusoft.AOP.Core.Abstraction
{
	public interface IInterceptorAspectContext
	{
		MethodInfo MethodBody { get; }
		bool Canceled { get; }
		void Cancel();
	}
}