using LancersSaveSelector.Core.Model;
using System.Collections.ObjectModel;

namespace LancersSaveSelector.Core.FileManager.Interface
{
	public interface ISaveFileManager
	{
		ActiveSaveFiles ActiveSaveFiles { get; }

		ObservableCollection<SaveFile> GetByChapter(int chapter, string fileType = "Default");
		Task LoadActiveFiles();

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
