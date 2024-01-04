using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using CommunityToolkit.Mvvm.Messaging;
using maui_backgrounding.Messaging;
using maui_backgrounding.Services;

namespace maui_backgrounding;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{

   public MainActivity()
   {

        WeakReferenceMessenger.Default.Register<MessageData>(this, (recipient, message) =>
        {
            if (message.Start)
            {
                StartService(message.Value);
            }
            else
            {
                StopService();
            }
        });
   }

   private void StartService(string input)
    {
        var serviceIntent = new Intent(this, typeof(FetchLyricsService));
        serviceIntent.PutExtra("inputExtra", input);
        
        StartService(serviceIntent);
    }
    
    private void StopService()
    {
        var serviceIntent = new Intent(this, typeof(FetchLyricsService));
        StopService(serviceIntent);
    }
}
