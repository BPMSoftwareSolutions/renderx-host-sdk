using Avalonia;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RenderX.HostSDK.Avalonia.Extensions;
using RenderX.HostSDK.Avalonia.Interfaces;

namespace RenderX.HostSDK.Sample;

internal static class Program
{
    public static void Main(string[] args)
    {
        BuildAvaloniaApp().Start(AppMain, args);
    }

    private static void AppMain(Application app, string[] args)
    {
        var services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        });

        services.AddRenderXHostSdk(options =>
        {
            options.EnableDebugLogging = true;
            options.OperationTimeoutMs = 30000;
        });

        var sp = services.BuildServiceProvider();

        var logger = sp.GetRequiredService<ILogger<MainWindow>>();
        var eventRouter = sp.GetRequiredService<IEventRouter>();

        var mainWindow = new MainWindow(eventRouter, logger)
        {
            Title = "RenderX Host SDK Sample"
        };
        mainWindow.Show();
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
                     .UsePlatformDetect()
                     .LogToTrace();
}

