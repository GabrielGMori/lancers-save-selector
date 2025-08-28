using LancersSaveSelector.Core.Model;
using System.Collections.ObjectModel;

namespace LancersSaveSelector.Core.FileManager.Interface
{
	public interface ISaveFileManager
	{
		SlotConfig SlotConfig { get; }

		ObservableCollection<SaveFile> GetByChapter(int chapter, string fileType = "Default");
		Task LoadSlotConfig();

		Task ReplaceSlot(int slot, SaveFile newSaveFile);
		Task EmptySlot(int slot);
		Task SwapSlots(int slot1, int slot2);

		Task RenameFile(SaveFile saveFile, string newName);
		void UpdateData(SaveFile saveFile, string newData);

		Task EraseFile(SaveFile saveFile);
		Task CopyFile(SaveFile saveFile);

		bool InGameFileExist(int chapter, string fileType = "Default");
		Task LoadFromGameFiles();
		Task SaveToGameFiles();

		Task CreateBackup();
		Task LoadBackup(string backupDirectoryPath);
	}
}
