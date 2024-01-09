using System.Reflection;

namespace BitzArt.Console;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class AppMenuAttribute : Attribute
{
    private readonly string _title = "Menu";

    public bool IsMain { get; set; } = false;

    public AppMenuAttribute(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Menu title cannot be empty.", nameof(title));
        }

        _title = title;
    }

    internal string GetTitle() => _title;
}

internal static class AppMenuAttributeExtensions
{
    public static AppMenuAttribute GetAppMenuAttribute(this Type type)
    {
        var attribute = type.GetCustomAttribute<AppMenuAttribute>()
            ?? throw new InvalidOperationException($"Menu {type.Name} must have {nameof(AppMenuAttribute)}");

        return attribute;
    }
}
