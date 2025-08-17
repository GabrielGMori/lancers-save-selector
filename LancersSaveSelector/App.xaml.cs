using LancersSaveSelector.FileManager.Interface;
using LancersSaveSelector.FileManager;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using LancersSaveSelector.Windows.MainWindow.Interface;
using LancersSaveSelector.Windows.MainWindow;

namespace LancersSaveSelector
{
	public partial class App : Application
	{
		private IServiceProvider? _serviceProvider;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ServiceCollection serviceCollection = new();
			ConfigureServices(serviceCollection);

			_serviceProvider = serviceCollection.BuildServiceProvider();

			MainWindow mainWindow  = _serviceProvider.GetRequiredService<MainWindow>();
			mainWindow.Show();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			// FileManager
			services.AddSingleton<IMainConfigManager, MainConfigManager>();
			services.AddSingleton<ISaveFileManager, SaveFileManager>();

			// ViewModel
			services.AddSingleton<IMainViewModel, MainViewModel>();

			// View
			services.AddSingleton<MainWindow>();
		}

		private void OnExit(object sender, EventArgs e)
		{
			if (_serviceProvider is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}
}
