using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BitzArt.Console;

public static class AddConsoleMenuExtensions
{
    /// <summary>
    /// Registers all console menus defined in the assembly containing this type in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IServiceCollection AddConsoleMenusFromAssemblyContaining<TAssemblyPointer>(this IServiceCollection services)
        => services.AddConsoleMenusFromAssemblyContaining(typeof(TAssemblyPointer));

    /// <summary>
    /// Registers all console menus defined in the assembly containing this type in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IServiceCollection AddConsoleMenusFromAssemblyContaining(this IServiceCollection services, Type type)
        => services.AddConsoleMenusFromAssembly(type.Assembly);

    /// <summary>
    /// Registers all console menus defined in the assembly in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IServiceCollection AddConsoleMenusFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var tools = assembly
            .DefinedTypes
            .Where(x => x.IsAbstract == false)
            .Where(x => x.GetInterfaces().Contains(typeof(IConsoleMenu)));

        foreach (var tool in tools) services.AddConsoleMenu(tool);

        return services;
    }

    /// <summary>
    /// Registers a Console Menu of type <paramref name="TConsoleMenu"/> in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IServiceCollection AddConsoleMenu<TConsoleMenu>(this IServiceCollection services)
        where TConsoleMenu : class, IConsoleMenu
    {
        services.AddTransient<TConsoleMenu>();
        services.AddTransient<IConsoleMenu, TConsoleMenu>();

        return services;
    }

    /// <summary>
    /// Registers a Console Menu of <paramref name="type"/> in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IServiceCollection AddConsoleMenu(this IServiceCollection services, Type type)
    {
        if (type is null) throw new ArgumentException($"{nameof(type)} must not be null");
        if (type.IsAssignableTo(typeof(IConsoleMenu)) == false) throw new ArgumentException($"{type.Name} is not assignable to IConsoleMenu");

        services.AddTransient(type);
        services.AddTransient(x => (IConsoleMenu)x.GetRequiredService(type));

        return services;
    }
}
