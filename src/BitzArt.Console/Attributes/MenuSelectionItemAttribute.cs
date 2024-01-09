using System.Reflection;

namespace BitzArt.Console;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class MenuSelectionItemAttribute : Attribute
{
    private readonly string _name;
    public bool PauseOnComplete { get; set; } = false;

    public MenuSelectionItemAttribute(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Selection item name cannot be empty.", nameof(name));
        }

        _name = name;
    }

    internal string GetName() => _name;
}

internal static class MenuSelectionItemAttributeExtensions
{
    internal static IEnumerable<SelectionMethod> GetSelectionMethods(this Type type)
    {
        var allPublicMethods = type.GetMethods();

        var result = new List<SelectionMethod>();

        foreach (var method in allPublicMethods)
        {
            var attribute = method.GetCustomAttribute<MenuSelectionItemAttribute>();
            if (attribute is null) continue;

            result.Add(new SelectionMethod(attribute.GetName(), method, attribute.PauseOnComplete));
        }

        return result;
    }

    internal static MenuSelectionItemAttribute GetMenuSelectionItemAttribute(this MethodInfo method)
    {
        var attribute = method.GetCustomAttribute<MenuSelectionItemAttribute>()
            ?? throw new InvalidOperationException($"Method {method.Name} must have {nameof(MenuSelectionItemAttribute)}");

        return attribute;
    }
}
