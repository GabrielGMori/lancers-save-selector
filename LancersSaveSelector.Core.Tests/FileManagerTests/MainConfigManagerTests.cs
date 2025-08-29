using LancersSaveSelector.Core.FileManager;
using LancersSaveSelector.Core.Model;
using LancersSaveSelector.Core.Tests.Utility;
using LancersSaveSelector.Core.Utility;

namespace LancersSaveSelector.Core.Tests.FileManagerTests
{
	public class MainConfigManagerTests : IDisposable
	{
		private readonly string _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

		public static IEnumerable<object[]> MainConfigData => [
			["SeenIntro", true, new MainConfig(seenIntro: true)],
			["SeenIntro", false, new MainConfig(seenIntro: false)],
			["BackgroundTrack", 3, new MainConfig(backgroundTrack: 3)],
			["SaveFilesDirectory", "saveFilesDir", new MainConfig(saveFilesDirectory: "saveFilesDir")],
		];

		private string CreateConfigPath()
		{
			string tempMainDir = Path.Combine(_tempDir, Guid.NewGuid().ToString());
			Directory.CreateDirectory(tempMainDir);
			return Path.Combine(tempMainDir, "main_config.json");
		}

		[Fact]
		public async Task LoadFromFile_WhenFileDoesntExist_ShouldCreateNewFile()
		{
			string configPath = CreateConfigPath();

			MainConfigManager mainConfigManager = new(configPath);
			await mainConfigManager.LoadFromFile();

			Assert.True(File.Exists(configPath));
		}

		[Theory]
		[MemberData(nameof(MainConfigData))]
		public async Task LoadFromFile_WhenFileExists_ShouldLoadDataFromFile(string propertyName, object expectedValue, MainConfig config)
		{
			string configPath = CreateConfigPath();

			await JsonHandler.WriteToJson(configPath, config);

			MainConfigManager mainConfigManager = new(configPath);
			await mainConfigManager.LoadFromFile();

			Assert.Equal(expectedValue, ReflectionHandler.GetPropertyValue(mainConfigManager.MainConfig, propertyName));
		}

		[Fact]
		public async Task UpdateFile_WhenFileDoesntExist_ShouldCreateNewFile()
		{
			string configPath = CreateConfigPath();

			MainConfigManager mainConfigManager = new(configPath);
			await mainConfigManager.UpdateFile();

			Assert.True(File.Exists(configPath));
		}

		[Theory]
		[MemberData(nameof(MainConfigData))]
		public async Task UpdateFile_WhenFileExists_ShouldUpdateFileData(string propertyName, object expectedValue, MainConfig _)
		{
			string configPath = CreateConfigPath();

			MainConfigManager mainConfigManager = new(configPath);

			ReflectionHandler.SetPropertyValue(mainConfigManager.MainConfig, propertyName, expectedValue);
			await mainConfigManager.UpdateFile();

			MainConfig actualConfig = await JsonHandler.ReadJson<MainConfig>(configPath);

			Assert.Equal(expectedValue, ReflectionHandler.GetPropertyValue(actualConfig, propertyName));
		}

		public void Dispose()
		{
			if (Directory.Exists(_tempDir))
				Directory.Delete(_tempDir, true);
			GC.SuppressFinalize(this);
		}
	}
}
