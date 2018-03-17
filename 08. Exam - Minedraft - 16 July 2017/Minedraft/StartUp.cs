using System;
using System.Linq;

namespace Minedraft
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var draftManager = new DraftManager();

            var input = Console.ReadLine();

            while (true)
            {
                var inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var command = inputArgs[0];
                var arguments = inputArgs.Skip(1).ToList();

                switch (command)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(draftManager.RegisterHarvester(arguments));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(draftManager.RegisterProvider(arguments));
                        break;
                    case "Day":
                        Console.WriteLine(draftManager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(draftManager.Mode(arguments));
                        break;
                    case "Check":
                        Console.WriteLine(draftManager.Check(arguments));
                        break;
                    case "Shutdown":
                        Console.WriteLine(draftManager.ShutDown());
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentException();
                }

                input = Console.ReadLine();
            }
        }
    }
}
