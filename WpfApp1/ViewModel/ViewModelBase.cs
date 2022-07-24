using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace  WpfApp1.ViewModel.ViewModel
{
    abstract public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
