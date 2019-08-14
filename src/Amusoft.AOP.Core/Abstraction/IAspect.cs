namespace Amusoft.AOP.Core.Abstraction
{
	public interface IAspect
	{
		/// <summary>
		/// Order in which an aspect is applied in ascending order.
		/// </summary>
		int ExecutionOrder { get; set; }

		/// <summary>
		/// Aspects are generated as fields within a scope specified by this value. This is relevant for state based programming.
		/// </summary>
		AspectScope Level { get; set; }
	}
}
