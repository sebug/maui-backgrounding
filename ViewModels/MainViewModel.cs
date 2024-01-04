using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Messaging;
using maui_backgrounding.Messaging;

namespace maui_backgrounding.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly IMessenger Messenger;
    public MainViewModel(IMessenger messenger)
    {
        Messenger = messenger;
    }

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

    public void StartFetching()
    {
        this.Messenger.Send(new Messaging.MessageData("Starting", true));
        this.StatusText = "Fetching";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}