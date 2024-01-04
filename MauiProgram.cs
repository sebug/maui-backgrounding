﻿using maui_backgrounding.Services;
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
			.AddViewModels()
			.AddViews();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
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
		appBuilder.Services.AddSingleton<IFetchLyricsService, FetchLyricsService>();
		return appBuilder;
	}
}
