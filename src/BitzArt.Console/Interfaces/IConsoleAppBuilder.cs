using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public interface IConsoleAppBuilder
{
    public IConfiguration Configuration { get; }
    public IServiceCollection Services { get; }
    internal MenuMap MenuMap { get; }

    public ConsoleApp Build();
}