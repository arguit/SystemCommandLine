using System.CommandLine;
using System.CommandLine.Invocation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SystemCommandLineHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<string>(new [] { "-c", "--configuration" },"Name of build configuration"),
                new Option<bool>(new [] { "-p", "--publish" }, "Publish after build"),
            };

            rootCommand.Description = $"Test appliacation to learn basics of System.CommandLine";
            rootCommand.Handler = CommandHandler.Create<Arguments>(Run);
            rootCommand.Invoke(args);
        }

        static void Run(Arguments arguments) =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<Arguments>(arguments);
                    services.AddHostedService<Worker>();
                })
                .Build()
                .Run();

    }
}
