using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Core.App;
using HtmlAgilityPack;

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
        if (intent != null)
        {
            var input = intent.GetStringExtra("inputExtra");
    
            var notificationIntent = new Intent(this, typeof(MainActivity));
            PendingIntentFlags intentFlags = 0;
            if (OperatingSystem.IsAndroidVersionAtLeast(23))
            {
                intentFlags = PendingIntentFlags.Immutable;
            }
            var pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent, intentFlags);
            
            var notification = new NotificationCompat.Builder(this, MainApplication.ChannelId)
                .SetContentTitle("Example Service")
                .SetContentText(input)
                .SetSmallIcon(Resource.Drawable.notification_icon)
                .SetContentIntent(pendingIntent)
                .Build();
            
            StartForeground(1, notification);

            PerformFetch();
        }
 
        return StartCommandResult.NotSticky;
    }

    private async void PerformFetch() 
    {
        var content = await FetchLyrics();
        var doc = new HtmlDocument();
        doc.LoadHtml(content);
        var lyricsLines = doc.DocumentNode.Descendants("div")
        .Where(div => div.GetAttributeValue("data-testid", String.Empty) == "lyrics.lyricLine")
        .Select(line => line.InnerText)
        .ToList();

        StopSelf();
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