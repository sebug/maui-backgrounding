using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;

namespace maui_backgrounding.Services;

[Service]
public partial class FetchLyricsService : Service
{
    public override IBinder? OnBind(Intent? intent)
    {
        throw new NotImplementedException();
    }

    [return: GeneratedEnum]
    public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
    {
        if (intent.Action == "START_SERVICE")
        {
            FetchLyrics();
        }
        else if (intent.Action == "STOP_SERVICE")
        {
            StopForeground(true);//Stop the service
            StopSelfResult(startId);
        }
        return StartCommandResult.NotSticky;
    }

    public void StartFetchLyrics()
    {
        Intent startService = new Intent(MainActivity.ActivityCurrent, typeof(FetchLyricsService));
        startService.SetAction("START_SERVICE");
        MainActivity.ActivityCurrent.StartService(startService);
    }

    public void StopFetchLyrics()
    {
        Intent stopIntent = new Intent(MainActivity.ActivityCurrent, this.Class);
        stopIntent.SetAction("STOP_SERVICE");
        MainActivity.ActivityCurrent.StartService(stopIntent);
    }
}