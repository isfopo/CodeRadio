using CodeRadio.Services;
using CodeRadio.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace CodeRadio;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("FontAwesomeSolid-900.otf", "FontAwesomeSolid");
            });

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<RadioService>();
        builder.Services.AddSingleton<TimerService>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

