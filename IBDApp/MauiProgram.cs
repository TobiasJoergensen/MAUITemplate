using IBDApp.Services;
using IBDApp.ViewModels;
using IBDApp.Views;
using Microsoft.Extensions.Logging;

namespace IBDApp
{
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
                .RegisterViewModels()
                .RegisterServices()
                .RegisterRoutes()
                .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder) {
            mauiAppBuilder.Services.AddSingleton<DetailsPage>();
            mauiAppBuilder.Services.AddSingleton<OverviewPage>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<DetailsViewModel>();
            mauiAppBuilder.Services.AddSingleton<OverviewViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<IDetailsService, DetailsService>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterRoutes(this MauiAppBuilder mauiAppBuilder)
        {
            Routing.RegisterRoute("Overview", typeof(OverviewPage));
            Routing.RegisterRoute("Details", typeof(DetailsPage));

            return mauiAppBuilder;
        }
    }
}
