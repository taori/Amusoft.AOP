using System;
using System.Collections.Generic;
using System.Linq;
using Amusoft.AOP.Core;
using Amusoft.AOP.Core.Infrastructure;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;

namespace Amusoft.AOP.Build.Tasks
{
	public class FindTouchedFilesTask : Task
	{
		[Required]
		[Output]
		public ITaskItem[] TouchedFilePaths { get; set; }

		/// <inheritdoc />
		public override bool Execute()
		{
			try
			{
				var task = System.Threading.Tasks.Task.Run(() => TransformLocator.GetAffectedDocumentsAsync(BuildEngine.ProjectFileOfTaskNode));
				var affectedDocuments = task.Result;
				TouchedFilePaths = affectedDocuments.Select(d => new TaskItem(d.FilePath)).ToArray();

				return true;
			}
			catch (Exception e)
			{
				Log.LogErrorFromException(e);
				return false;
			}
		}
	}
}
