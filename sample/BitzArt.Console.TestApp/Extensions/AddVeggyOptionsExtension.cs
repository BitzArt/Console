using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public static class AddVeggyOptionsExtension
{
    public static void AddVeggyOptions(this IConsoleAppBuilder builder)
    {
        var options = builder.Configuration
            .GetRequiredSection(VeggyOptions.SectionName)
            .Get<VeggyOptions>()!;

        builder.Services.AddSingleton(options);
    }
}
