using LancersSaveSelector.ViewModel;
using System.Windows;

namespace LancersSaveSelector
{
    public partial class MainWindow : Window
    {
		public MainWindow()
        {
			InitializeComponent();
            MainWindowVM vm = new();
            DataContext = vm;
        }
    }
}
