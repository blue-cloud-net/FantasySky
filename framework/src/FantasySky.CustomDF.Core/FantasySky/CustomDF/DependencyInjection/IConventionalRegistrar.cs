using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FantasySky.CustomDF.DependencyInjection;

public interface IConventionalRegistrar
{
    void AddAssembly(IServiceCollection services, Assembly assembly);

    void AddTypes(IServiceCollection services, params Type[] types);

    void AddType(IServiceCollection services, Type type);
}