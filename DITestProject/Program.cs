using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using DITestProject.Storage;
using DITestProject.InputHandlerDebug;
using DITestProject.InputHandlerRelease;

namespace DITestProject
{
    class Program
    {
        static ServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            serviceProvider = InitDI();
            Console.WriteLine("What would you like to do? Type 'help' for available actions.");
            ReadInput();
        }

        static ServiceProvider InitDI()
        {
            return new ServiceCollection()
                .AddSingleton<IStorageService, StorageService>()
                .AddTransient<InputHandlerDebug.IInputHandler, InputHandlerDebug.InputHandler>()
                .AddTransient<InputHandlerRelease.IInputHandler, InputHandlerRelease.InputHandler>()
                .BuildServiceProvider();
        }

        static void ReadInput()
        {
            string input = Console.ReadLine().Trim();

            Regex regex = new Regex(@"^(help|list|add)\s*(.*)$", RegexOptions.IgnoreCase);
            Match match = regex.Match(input);

            if (match.Success)
            {
                if (match.Groups[1].Value == "help")
                {
                    Console.Clear();
                    Console.WriteLine("Available actions:");
                    Console.WriteLine("add {value} - saves an entry with the current date, time and {value}");
                    Console.WriteLine("list - lists all saved values");
                    Console.WriteLine("help - shows this info");
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do?");
                    ReadInput();
                }
                else if (match.Groups[1].Value == "list")
                {
                    Console.Clear();
#if DEBUG
                    var service = serviceProvider.GetService<InputHandlerDebug.IInputHandler>();
#else
                    var service = serviceProvider.GetService<InputHandlerRelease.IInputHandler>();
#endif
                    var data = service.ReadEntries();
                    foreach (var entry in data)
                    {
                        Console.WriteLine(entry.Key + " - " + entry.Value);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do? Type 'help' for available actions.");
                    ReadInput();
                }
                else if (match.Groups[1].Value == "add")
                {
                    Console.Clear();
                    string inputValue = match.Groups[2].Value.Trim();
                    if (inputValue != "") {
#if DEBUG
                        var service = serviceProvider.GetService<InputHandlerDebug.IInputHandler>();
#else
                        var service = serviceProvider.GetService<InputHandlerRelease.IInputHandler>();
#endif
                        service.AddEntry(inputValue);
                        Console.WriteLine("Entry '" + inputValue + "' added on " + DateTime.Now);
                        Console.WriteLine("What would you like to do next? Type 'help' for available actions.");
                        ReadInput();
                    }
                    else
                    {
                        Console.WriteLine("Error: You can't add an empty value to the database. Try again or type 'help' for available actions.");
                        ReadInput();
                    }
                }
            }
            else if (input == "")
            {
                Console.Clear();
                Console.WriteLine("What would you like to do? Type 'help' for available actions.");
                ReadInput();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: Unknown action. Try again or type 'help' for available actions.");
                ReadInput();
            }


        }
    }
}
