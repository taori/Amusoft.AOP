using System;
using System.Collections.Generic;
using System.Linq;
using Amusoft.AOP.Core.Abstraction;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Amusoft.AOP.Core.UnitTests.Utility
{
	public static class CompilationHelper
	{
		public static Compilation CreateCompilation(IEnumerable<SyntaxTree> syntaxTrees, Func<CSharpCompilationOptions, CSharpCompilationOptions> optionsCallback = null, IEnumerable<Type> additionalMetadataTypes = null)
		{
			var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
				.WithGeneralDiagnosticOption(ReportDiagnostic.Error);
			options = optionsCallback?.Invoke(options);

			var defaultMetadataTypes = new[] {typeof(object), typeof(IAspect)};
			var mergedTypes = additionalMetadataTypes != null ? additionalMetadataTypes.Concat(defaultMetadataTypes) : defaultMetadataTypes;

			return CSharpCompilation.Create(DateTime.Now.Ticks.ToString(), syntaxTrees, mergedTypes.Select(d => MetadataReference.CreateFromFile(d.Assembly.Location)), options);
		}
	}
}