using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Messaging;
using maui_backgrounding.Messaging;

namespace maui_backgrounding.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public MainViewModel()
    {
        WeakReferenceMessenger.Default.Register<LyricsLineMessageData>(this, (recipient, message) =>
        {
            this.LyricsLine = message.Value;
        });
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

    private string _lyricsLine = String.Empty;
    public string LyricsLine
    {
        get => _lyricsLine;
        set
        {
            if (value != _lyricsLine)
            {
                _lyricsLine = value;
                OnPropertyChanged();
            }
        }
    }

    public void StartFetching()
    {
        WeakReferenceMessenger.Default.Send(new Messaging.MessageData("Starting", true));
        this.StatusText = "Fetching";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}