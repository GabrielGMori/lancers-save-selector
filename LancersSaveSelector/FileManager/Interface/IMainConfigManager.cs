using LancersSaveSelector.Model;

namespace LancersSaveSelector.FileManager.Interface
{
	internal interface IMainConfigManager
	{
		MainConfig MainConfig { get; }

		void Load();
		void Update(MainConfig newConfig);
	}
}
