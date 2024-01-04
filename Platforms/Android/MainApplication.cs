using Android.App;
using Android.OS;
using Android.Runtime;

namespace maui_backgrounding;

[Application]
public class MainApplication : MauiApplication
{
	public static readonly string ChannelId = "fetchLyricsServiceChannel";

	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

    public override void OnCreate()
    {
        base.OnCreate();
		if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
  		{
#pragma warning disable CA1416
    		var serviceChannel =
				new NotificationChannel(ChannelId, "Fetch Lyrics Service Channel", NotificationImportance.Default);
			
				if (GetSystemService(NotificationService) is NotificationManager manager)
				{
					manager.CreateNotificationChannel(serviceChannel);
				}
#pragma warning restore CA1416
   		}
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
