using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace Amusoft.AOP.Core.Infrastructure
{
	public static class TransformLocator
	{
		public static async Task<ImmutableArray<Document>> GetAffectedDocumentsAsync(string projectFileName)
		{
			var workspace = MSBuildWorkspace.Create();
			var project = await workspace.OpenProjectAsync(projectFileName).ConfigureAwait(false);
			var compilation = await project.GetCompilationAsync();

			var attributesInDocuments = project.Documents
				.Select(document => (hasTree: document.TryGetSyntaxTree(out var tree), tree, document))
				.Where(d => d.hasTree && IsTransformable(compilation, d.tree))
				.Select(d => (d.document, d.tree, attributes: SyntaxBrowser.GetAttributeSyntaxInTree(compilation, d.tree).ToImmutableArray()))
				.ToDictionary(d => d.document);

			if(attributesInDocuments.SelectMany(d => d.Value.attributes).Any(SyntaxAnalyzer.IsAssemblyAttribute))
				return new ImmutableArray<Document>().AddRange(project.Documents);

			return new ImmutableArray<Document>().AddRange(attributesInDocuments.Where(d => d.Value.attributes.Length > 0).Select(d => d.Key));
		}

		public static bool IsTransformable(Compilation compilation, SyntaxTree syntaxTree)
		{
			var attributes = SyntaxBrowser.GetAttributeSyntaxInTree(compilation, syntaxTree);
			if (attributes.Any(SyntaxAnalyzer.IsAssemblyAttribute))
				return true;

			return attributes.Any();
		}
	}
}