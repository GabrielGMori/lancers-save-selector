using LancersSaveSelector.Core.FileManager.Interface;
using LancersSaveSelector.Core.Model;
using LancersSaveSelector.Core.Utility;

namespace LancersSaveSelector.Core.FileManager
{
	internal class MainConfigManager : IMainConfigManager
	{
		public MainConfig MainConfig { get; private set; } = new MainConfig();

		private readonly string _mainDirectory = AppDomain.CurrentDomain.BaseDirectory;

		public async Task LoadFromFile()
		{
			try { MainConfig = await JsonHandler.ReadJson<MainConfig>(Path.Combine(_mainDirectory, "main_config.json")); }
			catch { throw; }
		}

		public async Task UpdateFile()
		{
			try { await JsonHandler.WriteToJson(Path.Combine(_mainDirectory, "main_config.json"), MainConfig); }
			catch { throw; }
		}
	}
}
