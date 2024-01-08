using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public interface IConsoleAppBuilder
{
    IConfiguration Configuration { get; }
    IServiceCollection Services { get; }

    ConsoleApp Build();
}