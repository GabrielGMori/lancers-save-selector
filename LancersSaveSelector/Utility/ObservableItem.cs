using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LancersSaveSelector.Windows.Utility
{
	internal class ObservableItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
