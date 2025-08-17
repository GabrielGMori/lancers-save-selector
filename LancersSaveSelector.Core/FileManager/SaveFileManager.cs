using LancersSaveSelector.Core.FileManager.Interface;
using LancersSaveSelector.Core.Model;
using LancersSaveSelector.Core.Utility;
using System.Collections.ObjectModel;

namespace LancersSaveSelector.Core.FileManager
{
	internal class SaveFileManager(IMainConfigManager mainConfigManager) : ISaveFileManager
	{
		private readonly IMainConfigManager _mainConfigManager = mainConfigManager;
		private readonly string _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data");
		public ActiveSaveFiles ActiveSaveFiles { get; private set; } = new();

		public ObservableCollection<SaveFile> GetByChapter(int chapter, string fileType = "Default")
		{
			if (fileType != "Default" && fileType != "Completion")
			{
				throw new ArgumentException($"{nameof(fileType)} needs to be either Default or Completion");
			}

			string chapterDirectory = Path.Combine(_dataDirectory, fileType, $"Chapter{chapter}");
			ObservableCollection<SaveFile> saveFiles = [];

			try
			{
				foreach (string currentFile in Directory.GetFiles(chapterDirectory))
				{
					string author = File.ReadLines(currentFile).First();

					string fileName = currentFile[(chapterDirectory.Length + 1)..];
					int? slot = null;

					for (int i = 0; i < 3; i++)
					{
						if (ActiveSaveFiles.FileDict[fileType][$"Chapter{chapter}"][i] == null)
						{
							slot = i;
						}
					}

					saveFiles.Add(new SaveFile(fileName, author, chapter, fileType, slot));
				}
				return saveFiles;
			}
			catch { throw; }
		}

		public async Task LoadActiveFiles()
		{
			try
			{
				ActiveSaveFiles = await JsonHandler.ReadJson<ActiveSaveFiles>(Path.Combine(_dataDirectory, "slot_config.json"));
			}
			catch { throw; }
		}

		public void ReplaceSlot(int slot, SaveFile newSaveFile)
		{
			throw new NotImplementedException();
		}
		public void EmptySlot(int slot)
		{
			throw new NotImplementedException();
		}
		public void SwapSlots(int slot1, int slot2)
		{
			throw new NotImplementedException();
		}
		public void RenameFile(SaveFile saveFile, string newName)
		{
			throw new NotImplementedException();
		}
		public void UpdateData(SaveFile saveFile, string newData)
		{
			throw new NotImplementedException();
		}
		public void EraseFile(SaveFile saveFile)
		{
			throw new NotImplementedException();
		}
		public void CopyFile(SaveFile saveFile)
		{
			throw new NotImplementedException();
		}
		public bool InGameFileExist(int chapter, string fileType = "Default")
		{
			throw new NotImplementedException();
		}
		public void LoadFromGameFiles()
		{
			throw new NotImplementedException();
		}
		public void SaveToGameFiles()
		{
			throw new NotImplementedException();
		}
		public void CreateBackup()
		{
			throw new NotImplementedException();
		}
		public void LoadBackup(string backupDirectoryPath)
		{
			throw new NotImplementedException();
		}
	}
}
