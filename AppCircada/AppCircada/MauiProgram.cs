using AppCircada.View;
using AppCircada.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace AppCircada;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("FuturaStd-Bold.otf", "FuturaBold");
            fonts.AddFont("FuturaStd-Heavy.otf", "FuturaHeavy");
            fonts.AddFont("FuturaStd-Light.otf", "FuturaLight");
            fonts.AddFont("FuturaPTBook.otf", "FuturaBook");
            fonts.AddFont("FuturaPTMedium.otf", "FuturaMedium");
            fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FA-Regular");
            fonts.AddFont("Font Awesome 6 Free-Solid-900", "FA-Solid");
        });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        //Registro de ViewModels
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<QuizSelectorViewModel>();
        builder.Services.AddTransient<QuizPageViewModel>();
        //Registro de páginas
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<QuizStartPage>();
        builder.Services.AddTransient<QuizPage>();
        builder.Services.AddTransient<QuizResultsPage>();
        builder.Services.AddSingleton<AboutPage>();
        return builder.Build();
    }
}