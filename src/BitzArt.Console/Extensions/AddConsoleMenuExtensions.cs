using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BitzArt.Console;

public static class AddConsoleMenuExtensions
{
    /// <summary>
    /// Registers all console menus defined in the assembly containing this type in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IConsoleAppBuilder AddConsoleMenusFromAssemblyContaining<TAssemblyPointer>(this IConsoleAppBuilder builder)
        => builder.AddConsoleMenusFromAssemblyContaining(typeof(TAssemblyPointer));

    /// <summary>
    /// Registers all console menus defined in the assembly containing this type in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IConsoleAppBuilder AddConsoleMenusFromAssemblyContaining(this IConsoleAppBuilder builder, Type type)
        => builder.AddConsoleMenusFromAssembly(type.Assembly);

    /// <summary>
    /// Registers all console menus defined in the assembly in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IConsoleAppBuilder AddConsoleMenusFromAssembly(this IConsoleAppBuilder builder, Assembly assembly)
    {
        var tools = assembly
            .DefinedTypes
            .Where(x => x.IsAbstract == false)
            .Where(x => x.GetCustomAttributes<AppMenuAttribute>().Any());

        foreach (var tool in tools) builder.AddConsoleMenu(tool);

        return builder;
    }

    /// <summary>
    /// Registers a Console Menu of type <paramref name="TConsoleMenu"/> in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IConsoleAppBuilder AddConsoleMenu<TConsoleMenu>(this IConsoleAppBuilder builder)
        where TConsoleMenu : class
    {
        builder.Services.AddTransient<TConsoleMenu>();

        var map = builder.MenuMap;
        map.Add(typeof(TConsoleMenu));

        return builder;
    }

    /// <summary>
    /// Registers a Console Menu of <paramref name="type"/> in the <see cref="IServiceCollection"/>
    /// </summary>
    public static IConsoleAppBuilder AddConsoleMenu(this IConsoleAppBuilder builder, Type type)
    {
        if (type is null) throw new ArgumentException($"{nameof(type)} must not be null");

        builder.Services.AddTransient(type);

        var map = builder.MenuMap;
        map.Add(type);

        return builder;
    }
}
