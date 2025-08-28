using LancersSaveSelector.Core.FileManager.Interface;
using LancersSaveSelector.Core.Model;
using LancersSaveSelector.Core.Utility;
using System.Collections.ObjectModel;

namespace LancersSaveSelector.Core.FileManager
{
	public class SaveFileManager(IMainConfigManager mainConfigManager, string dataDirectoryPath, string backupsDirectoryPath) : ISaveFileManager
	{
		private readonly IMainConfigManager _mainConfigManager = mainConfigManager;
		public SlotConfig SlotConfig { get; private set; } = new();

		private readonly string _slotConfigPath = Path.Combine(dataDirectoryPath, "slot_config.json");
		private readonly string _defaultFilesPath = Path.Combine(dataDirectoryPath, "Default");
		private readonly string _completionFilesPath = Path.Combine(dataDirectoryPath, "Completion");


		// File and Directory Ensures
		private void EnsureDataDirectory()
		{
			if (!Directory.Exists(dataDirectoryPath))
			{
				Directory.CreateDirectory(dataDirectoryPath);
			}
		}

		private void EnsureBackupsDirectory()
		{
			if (!Directory.Exists(backupsDirectoryPath))
			{
				Directory.CreateDirectory(backupsDirectoryPath);
			}
		}

		private async Task EnsureSlotConfigFile()
		{
			EnsureDataDirectory();
			if (!File.Exists(_slotConfigPath))
			{
				SlotConfig = new SlotConfig();
				await JsonHandler.WriteToJson(_slotConfigPath, SlotConfig);
			}
		}

		private void EnsureSaveFilesDirectories()
		{
			EnsureDataDirectory();
			if (!Directory.Exists(_defaultFilesPath))
			{
				Directory.CreateDirectory(_defaultFilesPath);
				for (int i = 1; i <= 4; i++)
				{
					Directory.CreateDirectory(Path.Combine(_defaultFilesPath, $"Chapter{i}"));
				}
			}
			if (!Directory.Exists(_completionFilesPath))
			{
				Directory.CreateDirectory(_completionFilesPath);
				for (int i = 1; i <= 4; i++)
				{
					Directory.CreateDirectory(Path.Combine(_completionFilesPath, $"Chapter{i}"));
				}
			}
		}

		// Slots
		public async Task LoadSlotConfig()
		{
			await EnsureSlotConfigFile();
			SlotConfig = await JsonHandler.ReadJson<SlotConfig>(_slotConfigPath);
		}

		public async Task ReplaceSlot(int slot, SaveFile newSaveFile)
		{
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}
		public async Task EmptySlot(int slot)
		{
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}
		public async Task SwapSlots(int slot1, int slot2)
		{
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}

		// Save Files
		public ObservableCollection<SaveFile> GetByChapter(int chapter, string fileType = "Default")
		{
			EnsureSaveFilesDirectories();
			if (fileType != "Default" && fileType != "Completion")
			{
				throw new ArgumentException($"{nameof(fileType)} needs to be either Default or Completion");
			}

			string chapterDirectory = Path.Combine(dataDirectoryPath, fileType, $"Chapter{chapter}");
			ObservableCollection<SaveFile> saveFiles = [];

			foreach (string currentFile in Directory.GetFiles(chapterDirectory))
			{
				string author = File.ReadLines(currentFile).First();

				string fileName = currentFile[(chapterDirectory.Length + 1)..];
				int? slot = null;

				for (int i = 0; i < 3; i++)
				{
					if (SlotConfig.FileDict[fileType][$"Chapter{chapter}"][i] == null)
					{
						slot = i;
					}
				}

				saveFiles.Add(new SaveFile(fileName, author, chapter, fileType, slot));
			}
			return saveFiles;
		}

		public async Task RenameFile(SaveFile saveFile, string newName)
		{
			EnsureSaveFilesDirectories();
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}
		public void UpdateData(SaveFile saveFile, string newData)
		{
			EnsureSaveFilesDirectories();
			throw new NotImplementedException();
		}
		public async Task EraseFile(SaveFile saveFile)
		{
			EnsureSaveFilesDirectories();
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}
		public async Task CopyFile(SaveFile saveFile)
		{
			EnsureSaveFilesDirectories();
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}

		// Game's Save Files
		public bool InGameFileExist(int chapter, string fileType = "Default")
		{
			throw new NotImplementedException();
		}
		public async Task LoadFromGameFiles()
		{
			EnsureSaveFilesDirectories();
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}
		public async Task SaveToGameFiles()
		{
			EnsureSaveFilesDirectories();
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}

		// Backups
		public async Task CreateBackup()
		{
			EnsureSaveFilesDirectories();
			EnsureBackupsDirectory();
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}
		public async Task LoadBackup(string backupDirectoryPath)
		{
			EnsureSaveFilesDirectories();
			EnsureBackupsDirectory();
			await EnsureSlotConfigFile();
			throw new NotImplementedException();
		}
	}
}
