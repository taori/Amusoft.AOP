using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Amusoft.AOP.Core.Infrastructure
{
	internal static class SyntaxAnalyzer
	{
		public static bool IsAssemblyAttribute(AttributeSyntax syntax)
		{
			var attributeList = syntax.Ancestors().OfType<AttributeListSyntax>().FirstOrDefault();
			if (attributeList == null)
				return false;

			var targetSpecifierSyntax = attributeList.ChildNodes().OfType<AttributeTargetSpecifierSyntax>().FirstOrDefault();
			if (targetSpecifierSyntax?.Kind() == SyntaxKind.AssemblyKeyword)
				return true;

			return false;
		}
	}
}