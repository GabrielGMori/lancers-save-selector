using LancersSaveSelector.Windows.FileManager;
using LancersSaveSelector.Windows.FileManager.Interface;
using LancersSaveSelector.Windows.Model;
using LancersSaveSelector.Windows.Utility;
using LancersSaveSelector.Windows.MainWindow.Interface;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LancersSaveSelector.Windows.MainWindow
{
	internal class MainViewModel : ObservableItem, IMainViewModel
	{
		private readonly IMainConfigManager _mainConfigManager;
		private readonly ISaveFileManager _saveFileManager;

		private int _configVariable;
		public int ConfigVariable
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
				_saveFileManager.LoadActiveFiles();
				_mainConfigManager.LoadFromFile();
				ConfigVariable = _mainConfigManager.MainConfig.BackgroundTrack;
			}
			catch
			{
				ConfigVariable = 500;
			}
		}

		public void Change()
		{
			var file = _saveFileManager.ActiveSaveFiles.FileDict["Default"]["Chapter1"][0];

			if (file == null)
			{
				ConfigVariable = 404;
			}
			else
			{
				ConfigVariable = 200;
			}
		}
	}
}
