using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace SystemCommandLineBasic
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

            rootCommand.Description = $"{nameof(SystemCommandLineBasic)}";
            rootCommand.Handler = CommandHandler.Create<string, bool>(Execute);
            rootCommand.Invoke(args);
        }

        static void Execute(string configuration, bool publish)
        {
            Console.WriteLine($"Building using Profile={configuration} and Publish={publish}");
        }
    }
}
