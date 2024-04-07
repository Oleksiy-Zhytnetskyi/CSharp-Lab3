using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KMA.CSharp2024.Lab3.ViewModels.Abstract
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
