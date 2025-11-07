using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RenderX.HostSDK.Avalonia.Engine;
using RenderX.HostSDK.Avalonia.Interfaces;

namespace RenderX.HostSDK.Avalonia.Extensions;

/// <summary>
/// Extension methods for registering RenderX Host SDK services in the DI container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add RenderX Host SDK services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddRenderXHostSdk(this IServiceCollection services)
    {
        return services.AddRenderXHostSdk(options => { });
    }

    /// <summary>
    /// Add RenderX Host SDK services with custom configuration.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Configuration action for Host SDK options.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddRenderXHostSdk(
        this IServiceCollection services,
        Action<HostSdkOptions> configure)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        if (configure == null)
            throw new ArgumentNullException(nameof(configure));

        // Register options
        var options = new HostSdkOptions();
        configure(options);
        services.AddSingleton(options);

        // Register the engine host as a singleton
        services.AddSingleton<HostSdkEngineHost>(provider =>
        {
            var logger = provider.GetRequiredService<ILogger<HostSdkEngineHost>>();
            return new HostSdkEngineHost(logger);
        });

        // Register core services as singletons
        // Note: Actual implementations will be added in Phase 2
        // For Phase 1, we're just setting up the infrastructure

        // services.AddSingleton<IEventRouter, EventRouterService>();
        // services.AddSingleton<IInventoryAPI, InventoryService>();
        // services.AddSingleton<ICssRegistryAPI, CssRegistryService>();
        // services.AddSingleton<IConfigService, ConfigService>();
        // services.AddSingleton<IFeatureFlagsService, FeatureFlagsService>();
        // services.AddSingleton<IPluginManifestService, PluginManifestService>();
        // services.AddSingleton<IInteractionManifestService, InteractionManifestService>();
        // services.AddSingleton<ITopicsManifestService, TopicsManifestService>();

        return services;
    }
}

