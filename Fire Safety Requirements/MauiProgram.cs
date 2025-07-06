using CommunityToolkit.Maui;
using Fire_Safety_Requirements.ViewModel;
using Microsoft.Extensions.Logging;
using Plugin.MauiMTAdmob;
using UraniumUI;

namespace Fire_Safety_Requirements
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .UseMauiCommunityToolkit()
                .UseMauiMTAdmob()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("RedHatText-Italic-VariableFont_wght.ttf", "RedHatText-Italic-VariableFont_wght");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<OccupancyTypePage>();

            builder.Services.AddTransient<OccupancyTypeViewModel>();
            builder.Services.AddTransient<OccupancyTypePage>();

            builder.Services.AddTransient<OccupancyDetailViewModel>();
            builder.Services.AddTransient<OccupancyDetailPage>();
            builder.Services.AddTransient<SummaryViewModel>();
            builder.Services.AddTransient<SummaryPage>();
            builder.Services.AddTransient<MeansOfEgressPage>();
            builder.Services.AddTransient<MeansOfEgressViewModel>();
            builder.Services.AddTransient<InspectionFlowChartPage>();
            builder.Services.AddTransient<OtherFeesCalc>();
            builder.Services.AddTransient<OtherFeesCalcViewModel>();

            builder.Logging.AddDebug();
            
            return builder.Build();
        }
    }
}

