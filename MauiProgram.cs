using CommunityToolkit.Mvvm.Messaging;
using maui_backgrounding.Services;
using maui_backgrounding.ViewModels;
using Microsoft.Extensions.Logging;

namespace maui_backgrounding;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.AddMessenger()
			.AddViewModels()
			.AddViews()
			.AddServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	private static MauiAppBuilder AddMessenger(this MauiAppBuilder appBuilder)
	{
		appBuilder.Services.AddTransient<IMessenger, WeakReferenceMessenger>();
		return appBuilder;
	}

	private static MauiAppBuilder AddViewModels(this MauiAppBuilder appBuilder)
	{
		appBuilder.Services.AddTransient<MainViewModel>();
		return appBuilder;
	}

	private static MauiAppBuilder AddViews(this MauiAppBuilder appBuilder)
	{
		appBuilder.Services.AddSingleton<MainPage>();
		return appBuilder;
	}

	private static MauiAppBuilder AddServices(this MauiAppBuilder appBuilder)
	{
		
		return appBuilder;
	}
}
