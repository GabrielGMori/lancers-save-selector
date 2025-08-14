using System.IO;
using System.Text.Json;

namespace LancersSaveSelector.Utility
{
	public static class JsonHandler
	{
		private static readonly JsonSerializerOptions serializerOptions = new() { WriteIndented = true };

		public static async Task<T> ReadJson<T>(string filePath) where T : class
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException(nameof(filePath), $"{nameof(filePath)} cannot be empty.");
			}

			using Stream openReadStream = File.OpenRead(filePath);
			T? obj = await JsonSerializer.DeserializeAsync<T>(openReadStream);
			return obj ?? throw new Exception("Could not load JSON file.");
		}

		public static async void WriteToJson(string filePath, object obj)
		{
			string jsonString = JsonSerializer.Serialize(obj, serializerOptions);
			await File.WriteAllTextAsync(filePath, jsonString);
		}
	}
}
