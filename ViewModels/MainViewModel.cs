using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace maui_backgrounding.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string _statusText = "Initialized";
    public string StatusText
    {
        get => _statusText;
        set
        {
            if (value != _statusText)
            {
                _statusText = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}