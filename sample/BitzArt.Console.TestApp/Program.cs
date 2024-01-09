namespace BitzArt.Console;

internal class Program
{
    static void Main()
    {
        var builder = ConsoleApp.CreateBuilder();

        builder.AddConsoleMenusFromAssemblyContaining<Program>();
        builder.AddVeggyOptions();

        var app = builder.Build();

        app.Run();
    }
}
