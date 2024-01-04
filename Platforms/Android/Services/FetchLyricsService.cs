using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;

namespace maui_backgrounding.Services;

[Service]
public class FetchLyricsService : Service
{
    public override IBinder? OnBind(Intent? intent)
    {
        return null;
    }

    [return: GeneratedEnum]
    public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
    {
        if (intent != null && OperatingSystem.IsAndroidVersionAtLeast(24))
        {
            if (intent.Action == "START_SERVICE")
            {
                FetchLyrics();
            }
            else if (intent.Action == "STOP_SERVICE")
            {
                StopForeground(StopForegroundFlags.Remove);
                StopSelfResult(startId);
            }
        }
        return StartCommandResult.NotSticky;
    }

    private string _lyricsUrl = "https://lyrics.lyricfind.com/lyrics/death-cab-for-cutie-no-room-in-frame";
    protected async Task<string> FetchLyrics()
    {
        using (var client = new HttpClient())
        {
            string content = await client.GetStringAsync(_lyricsUrl);
            return content;
        }
    }
}