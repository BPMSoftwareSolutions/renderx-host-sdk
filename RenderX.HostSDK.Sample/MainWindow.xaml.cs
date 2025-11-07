using Avalonia.Controls;
using Microsoft.Extensions.Logging;
using RenderX.HostSDK.Avalonia.Interfaces;

namespace RenderX.HostSDK.Sample;

public class MainWindow : Window
{
    private readonly IEventRouter _eventRouter;
    private readonly ILogger<MainWindow> _logger;

    public MainWindow(IEventRouter eventRouter, ILogger<MainWindow> logger)
    {
        _eventRouter = eventRouter;
        _logger = logger;

        Title = "RenderX Host SDK Sample";
        Width = 1000;
        Height = 700;

        _logger.LogInformation("RenderX Host SDK Sample started");
    }
}

