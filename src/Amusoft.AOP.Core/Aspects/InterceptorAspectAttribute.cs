using System;
using Amusoft.AOP.Core.Abstraction;

namespace Amusoft.AOP.Core.Aspects
{
	public abstract class InterceptorAspect : Attribute, IInterceptorAspect
	{
		/// <inheritdoc />
		public abstract void Execute(IInterceptorAspectContext context);

		/// <inheritdoc />
		public int ExecutionOrder { get; set; }

		/// <inheritdoc />
		public AspectScope Level { get; set; }
	}
}