using LancersSaveSelector.Core.Model;

namespace LancersSaveSelector.Core.FileManager.Interface
{
	public interface IMainConfigManager
	{
		MainConfig MainConfig { get; }

		Task LoadFromFile();
		Task UpdateFile();
	}
}
