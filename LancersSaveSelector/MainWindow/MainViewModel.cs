using LancersSaveSelector.Core.FileManager.Interface;
using LancersSaveSelector.Windows.MainWindow.Interface;
using LancersSaveSelector.Windows.Utility;
using System.IO;

namespace LancersSaveSelector.Windows.MainWindow
{
	internal class MainViewModel : ObservableItem, IMainViewModel
	{
		private readonly IMainConfigManager _mainConfigManager;
		private readonly ISaveFileManager _saveFileManager;

		private string _configVariable;
		public string ConfigVariable
		{
			get { return _configVariable; }
			set
			{
				_configVariable = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand ChangeCommand => new(execute => Change());

		public MainViewModel(IMainConfigManager mainConfigManager, ISaveFileManager saveFileManager)
		{
			_mainConfigManager = mainConfigManager;
			_saveFileManager = saveFileManager;
			try
			{
				_saveFileManager.LoadSlotConfig();
				_mainConfigManager.LoadFromFile();
				_configVariable = _mainConfigManager.MainConfig.BackgroundTrack.ToString();
			}
			catch
			{
				_configVariable = "500";
			}
		}

		public void Change()
		{
			//var file = _saveFileManager.SlotConfig.FileDict["Default"]["Chapter1"][0];
			bool file = Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data"));

			if (file == false)
			{
				ConfigVariable = "404";
			}
			else
			{
				ConfigVariable = AppDomain.CurrentDomain.BaseDirectory.ToLower();
			}
		}
	}
}
