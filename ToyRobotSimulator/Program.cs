using System;
using Microsoft.Extensions.DependencyInjection;
using ToyRobot;
using CommandParser;
namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRobot, Robot>()
                .AddSingleton<IParser, Parser>()
                .BuildServiceProvider();

            var robot = serviceProvider.GetService<IRobot>();
            var commandParser = serviceProvider.GetService<IParser>();

            while (true)
            {
                Console.WriteLine("Enter a command:");
                var command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                    break;
                if (commandParser != null)
                {
                    commandParser.ParseCommand(command);
                }
                else
                {
                    Console.WriteLine("Invalid...");
                }
                
            }
        }
    }
}
