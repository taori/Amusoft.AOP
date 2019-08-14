using System;
using Amusoft.AOP.Core.Abstraction;

namespace Amusoft.AOP.Core.UnitTests.Mocks
{
	internal class DummyAspect : Attribute, IInterceptorAspect
	{
		/// <inheritdoc />
		public int ExecutionOrder { get; set; }

		/// <inheritdoc />
		public AspectScope Level { get; set; }

		/// <inheritdoc />
		public void Execute(IInterceptorAspectContext context)
		{
		}
	}

	internal class DummyInheritedAspect : DummyAspect
	{
	}
}