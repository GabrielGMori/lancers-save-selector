using System.Text.Json;

namespace LancersSaveSelector.Core.Utility
{
	public static class JsonHandler
	{
		private static readonly JsonSerializerOptions _serializerOptions = new() { WriteIndented = true };

		public static async Task<T> ReadJson<T>(string filePath) where T : class
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException(nameof(filePath), $"{nameof(filePath)} cannot be empty.");
			}
			else if (!File.Exists(filePath))
			{
				throw new FileNotFoundException($"No file found in {filePath}");
			}

			try
			{
				using Stream openReadStream = File.OpenRead(filePath);
				T? obj = await JsonSerializer.DeserializeAsync<T>(openReadStream);
				return obj ?? throw new Exception("Could not load JSON file.");
			}
			catch { throw; }
		}

		public static async Task WriteToJson(string filePath, object obj)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException(nameof(filePath), $"{nameof(filePath)} cannot be empty.");
			}
			else if (!File.Exists(filePath))
			{
				throw new FileNotFoundException($"No file found in {filePath}");
			}

			try
			{
				string jsonString = JsonSerializer.Serialize(obj, _serializerOptions);
				await File.WriteAllTextAsync(filePath, jsonString);
			}
			catch { throw; }
		}
	}
}
