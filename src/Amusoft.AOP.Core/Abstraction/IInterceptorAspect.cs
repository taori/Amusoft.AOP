namespace Amusoft.AOP.Core.Abstraction
{
	public interface IInterceptorAspect : IAspect
	{
		void Execute(IInterceptorAspectContext context);
	}
}