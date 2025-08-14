using System.Windows;

namespace LancersSaveSelector
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			MainWindow mainWindow = new();
			mainWindow.Show();
		}
	}
}
