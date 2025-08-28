using LancersSaveSelector.Core.FileManager.Interface;
using LancersSaveSelector.Core.Model;
using LancersSaveSelector.Core.Utility;

namespace LancersSaveSelector.Core.FileManager
{
	public class MainConfigManager(string configFilePath) : IMainConfigManager
	{
		public MainConfig MainConfig { get; private set; } = new MainConfig();

		public async Task LoadFromFile()
		{
			if (!File.Exists(configFilePath))
			{
				await UpdateFile();
			}
			MainConfig = await JsonHandler.ReadJson<MainConfig>(configFilePath);
		}

		public async Task UpdateFile()
		{
			await JsonHandler.WriteToJson(configFilePath, MainConfig);
		}
	}
}
