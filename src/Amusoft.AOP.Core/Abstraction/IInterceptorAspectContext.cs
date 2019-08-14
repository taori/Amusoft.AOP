using System.Reflection;

namespace Amusoft.AOP.Core.Abstraction
{
	/// <summary>
	/// This aspect can be used to control whether or not a method body will be executed.
	/// </summary>
	public interface IInterceptorAspectContext
	{
		/// <summary>
		/// reference to the executed method
		/// </summary>
		MethodInfo MethodBody { get; }

		/// <summary>
		/// Whether or not the execution has been canceled
		/// </summary>
		bool Canceled { get; }

		/// <summary>
		/// Cancels the execution context
		/// </summary>
		void Cancel();
	}
}