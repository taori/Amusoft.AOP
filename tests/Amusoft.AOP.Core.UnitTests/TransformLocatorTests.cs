using System.Collections.Generic;
using Amusoft.AOP.Core.Infrastructure;
using Amusoft.AOP.Core.UnitTests.Utility;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.FindSymbols;
using Shouldly;
using Xunit;

namespace Amusoft.AOP.Core.UnitTests
{
	public class TransformLocatorTests
	{
		[Fact]
		public void UnrelatedAssemblyAttributesShouldNotTrigger()
		{
			var syntaxTree = SyntaxTreeTestFactory.FromTestFilePath("UnrelatedAssemblyAttribute.cs");
			var compilation = CompilationHelper.CreateCompilation(new[] {syntaxTree});
			var transformable = TransformLocator.IsTransformable(compilation, syntaxTree);
			transformable.ShouldBe(false);
		}

		[Fact]
		public void UnrelatedLocalAttributesShouldNotTrigger()
		{
			var syntaxTree = SyntaxTreeTestFactory.FromTestFilePath("UnrelatedLocalAttribute.cs");
			var compilation = CompilationHelper.CreateCompilation(new[] {syntaxTree});
			var transformable = TransformLocator.IsTransformable(compilation, syntaxTree);
			transformable.ShouldBe(false);
		}

		[Fact]
		public void RelatedAssemblyAttributesShouldTrigger()
		{
			var syntaxTree = SyntaxTreeTestFactory.FromTestFilePath("RelatedAssemblyAttribute.cs");
			var compilation = CompilationHelper.CreateCompilation(new[] {syntaxTree});
			var transformable = TransformLocator.IsTransformable(compilation, syntaxTree);
			transformable.ShouldBe(true);
		}

		[Fact]
		public void RelatedLocalAttributesShouldTrigger()
		{
			var syntaxTree = SyntaxTreeTestFactory.FromTestFilePath("RelatedLocalAttribute.cs");
			var compilation = CompilationHelper.CreateCompilation(new[] {syntaxTree});
			var transformable = TransformLocator.IsTransformable(compilation, syntaxTree);
			transformable.ShouldBe(true);
		}

		[Fact]
		public void InheritedRelatedAssemblyAttributesShouldTrigger()
		{
			var syntaxTree = SyntaxTreeTestFactory.FromTestFilePath("InheritedRelatedAssemblyAttribute.cs");
			var compilation = CompilationHelper.CreateCompilation(new[] {syntaxTree});
			var transformable = TransformLocator.IsTransformable(compilation, syntaxTree);
			transformable.ShouldBe(true);
		}

		[Fact]
		public void InheritedRelatedLocalAttributesShouldTrigger()
		{
			var syntaxTree = SyntaxTreeTestFactory.FromTestFilePath("InheritedRelatedLocalAttribute.cs");
			var compilation = CompilationHelper.CreateCompilation(new[] {syntaxTree});
			var transformable = TransformLocator.IsTransformable(compilation, syntaxTree);
			transformable.ShouldBe(true);
		}
	}
}