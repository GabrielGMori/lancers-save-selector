using LancersSaveSelector.Windows.MainWindow.Interface;
using System.Windows;

namespace LancersSaveSelector
{
    public partial class MainWindow : Window
    {
		public MainWindow(IMainViewModel viewModel)
        {
			InitializeComponent();
            DataContext = viewModel;
        }
    }
}
