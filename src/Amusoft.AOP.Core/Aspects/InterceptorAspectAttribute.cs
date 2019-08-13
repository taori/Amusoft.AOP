using System;
using Amusoft.AOP.Core.Abstraction;

namespace Amusoft.AOP.Core.Aspects
{
	public class InterceptorAspectAttribute : Attribute, IInterceptorAspect
	{
		/// <inheritdoc />
		public void Execute(IInterceptorAspectContext context)
		{
		}
	}
}