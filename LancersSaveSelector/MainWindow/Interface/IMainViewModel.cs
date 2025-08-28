using LancersSaveSelector.Windows.Utility;

namespace LancersSaveSelector.Windows.MainWindow.Interface
{
	public interface IMainViewModel
	{
		string ConfigVariable { get; set; }
		RelayCommand ChangeCommand { get; }

		void Change();
	}
}
