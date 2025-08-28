using LancersSaveSelector.Core.FileManager.Interface;
using LancersSaveSelector.Core.FileManager;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using LancersSaveSelector.Windows.MainWindow.Interface;
using LancersSaveSelector.Windows.MainWindow;
using System.IO;

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

			IMainConfigManager mainConfigManager = _serviceProvider.GetRequiredService<IMainConfigManager>();
			ISaveFileManager saveFileManager = _serviceProvider.GetRequiredService<ISaveFileManager>();
			mainConfigManager.LoadFromFile();
			saveFileManager.LoadSlotConfig();

			MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
			mainWindow.Show();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			// Variables
			string mainConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"main_config.json");
			string dataDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data");
			string backupsDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Backups");

			// FileManager
			services.AddSingleton<IMainConfigManager>(sp => new MainConfigManager(mainConfigFilePath));
			services.AddSingleton<ISaveFileManager>(sp => new SaveFileManager(sp.GetRequiredService<IMainConfigManager>(), dataDirectoryPath, backupsDirectoryPath));

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
