using FantasySky.CustomDF;
using FantasySky.CustomDF.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtensions
{
    public static T? GetService<T>(this IServiceProvider provider, string serviceName)
        where T : class
    {
        Check.NotNull(provider, nameof(provider));
        Check.NotNullOrWhiteSpace(serviceName, nameof(serviceName));

        var namedServiceProvider = provider.GetService<INamedServiceProvider<T>>()
            ?? throw new InvalidOperationException($"No type '{typeof(T)}' of named service is registered in container.");

        return namedServiceProvider.GetService(serviceName);
    }

    public static T GetRequiredService<T>(this IServiceProvider provider, string serviceName)
        where T : class
    {
        Check.NotNull(provider, nameof(provider));
        Check.NotNullOrWhiteSpace(serviceName, nameof(serviceName));

        var namedServiceProvider = provider.GetService<INamedServiceProvider<T>>()
            ?? throw new InvalidOperationException($"No type '{typeof(T)}' of named service is registered in container.");

        return namedServiceProvider.GetRequiredService(serviceName);
    }
}
