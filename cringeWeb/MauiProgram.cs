using Microsoft.Extensions.Logging;
using Classes;
using Microsoft.EntityFrameworkCore;
namespace cringeWeb;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        if (AppDomain.CurrentDomain.BaseDirectory.Contains(@"\bin\"))
        {
            Environment.CurrentDirectory =
                AppDomain.CurrentDomain.BaseDirectory.Substring(0,
                    AppDomain.CurrentDomain.BaseDirectory.IndexOf("cringeWeb"));
        }
        
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseSqlite($"Data Source={Environment.CurrentDirectory + @"\MyDatabase.db"}");
        });
        var app = builder.Build();
        var dbContext = app.Services.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();

        return builder.Build();
    }
}