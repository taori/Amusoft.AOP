using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Amusoft.AOP.Core.UnitTests.Utility
{
	public static class SyntaxTreeTestFactory
	{
		public static SyntaxTree FromTestFilePath(string path)
		{
			using (var stream = FileUtility.GetEmbeddedFileStream(path))
			{
				return CSharpSyntaxTree.ParseText(SourceText.From(stream.BaseStream, Encoding.UTF8));
			}
		}
	}
}