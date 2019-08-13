using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Amusoft.AOP.Core.UnitTests.Utility
{
	public static class FileUtility
	{
		private static string GetManifestFilePath(string path)
		{
			return $"{Assembly.GetAssembly(typeof(FileUtility)).GetName().Name}.TestContent.{path}";
		}

		public static StreamReader GetEmbeddedFileStream(string path)
		{
			var manifestFilePath = GetManifestFilePath(path);
			var stream = typeof(FileUtility).Assembly.GetManifestResourceStream(manifestFilePath);
			return new StreamReader(stream, Encoding.UTF8, true, 1024, true);
		}

		public static async Task<T> GetEmbeddedJsonAsync<T>(string path)
		{
			using (var reader = GetEmbeddedFileStream(path))
			{
				return JsonConvert.DeserializeObject<T>(await reader.ReadToEndAsync());
			}
		}
	}
}