using System.Collections.Generic;
using System.Linq;
using Amusoft.AOP.Core.Abstraction;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Amusoft.AOP.Core.Infrastructure
{
	internal static class SyntaxBrowser
	{
		public static IEnumerable<AttributeSyntax> GetAttributeSyntaxInTree(Compilation compilation, SyntaxTree syntaxTree)
		{
			var markerSymbol = compilation.GetTypeByMetadataName(typeof(IAspect).FullName);
			var semanticModel = compilation.GetSemanticModel(syntaxTree);
			foreach (var attributeSyntax in syntaxTree.GetRoot().DescendantNodes().OfType<AttributeSyntax>())
			{
				var attributeTypeInfo = semanticModel.GetTypeInfo(attributeSyntax);
				if (attributeTypeInfo.Type.AllInterfaces.Any(d => d.Equals(markerSymbol)))
					yield return attributeSyntax;
			}
		}
	}
}