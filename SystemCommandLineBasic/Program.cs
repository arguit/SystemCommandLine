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

            rootCommand.Description = $"Test appliacation to learn basics of System.CommandLine";
            rootCommand.Handler = CommandHandler.Create<Arguments>(Run);
            rootCommand.Invoke(args);
        }

        static void Run(Arguments arguments)
        {
            Console.WriteLine($"Building using Profile={arguments.Configuration} and Publish={arguments.Publish}");
        }
    }
}
