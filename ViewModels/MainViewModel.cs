using System.ComponentModel;
using System.Runtime.CompilerServices;
using maui_backgrounding.Services;

namespace maui_backgrounding.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly IFetchLyricsService FetchLyricsService;
    public MainViewModel(IFetchLyricsService fetchLyricsService)
    {
        FetchLyricsService = fetchLyricsService;
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
        this.FetchLyricsService.StartFetchLyrics();
        this.StatusText = "Fetching";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}