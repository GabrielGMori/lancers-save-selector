using LancersSaveSelector.Model;
using System.Collections.ObjectModel;

namespace LancersSaveSelector.FileManager.Interface
{
	internal interface ISaveFileManager
	{
		Task<ObservableCollection<SaveFile>> GetByChapter(int chapter, string fileType = "Default");
		Task<ActiveSaveFileList> GetActive();

		void ReplaceSlot(int slot, SaveFile newSaveFile);
		void EmptySlot(int slot);
		void SwapSlots(int slot1, int slot2);

		void RenameFile(SaveFile saveFile, string newName);
		void UpdateData(SaveFile saveFile, string newData);

		void EraseFile(SaveFile saveFile);
		void CopyFile(SaveFile saveFile);

		bool InGameFileExist(int chapter, string fileType = "Default");
		void LoadFromGameFiles();
		void SaveToGameFiles();

		void CreateBackup();
		void LoadBackup(string backupDirectoryPath);
	}
}
