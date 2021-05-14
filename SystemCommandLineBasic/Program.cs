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
                new Option<string>(
                    aliases: new string[] { "--configuration", "-c"},
                    getDefaultValue: () => "Release-Dev",
                    description: "Name of build profile to be used"
                ),
                new Option<bool>(
                    aliases: new string[] { "--publish", "-p" },
                    getDefaultValue: () => false,
                    description: "Set to publish after build"
                )
            };

            rootCommand.Description = $"{nameof(SystemCommandLineBasic)}";

            rootCommand.Handler = CommandHandler.Create<string, bool>(Execute);

            rootCommand.InvokeAsync(args);
        }

        static void Execute(string configuration, bool publish)
        {
            Console.WriteLine($"Building using Profile={configuration} and Publish={publish}");
        }
    }
}
