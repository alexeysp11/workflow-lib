using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowLib.DataStorage.InMemoryService.Cli
{
    public class Program
    {
        private static string? _currentServerAddress = null;
        private static bool _isConnected = false;

        public static async Task Main(string[] args)
        {
            Console.WriteLine("IN-MEMORY SERVICE CLI");

            while (true)
            {
                if (_isConnected)
                {
                    Console.Write($"{_currentServerAddress}> ");
                }
                else
                {
                    Console.Write(">>> ");
                }

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    await ExecuteCommand(parts);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static async Task ExecuteCommand(string[] parts)
        {
            if (parts.Length == 0)
            {
                return;
            }

            string command = parts[0].ToLowerInvariant();

            switch (command)
            {
                case "connect":
                    await Connect(parts);
                    break;
                case "disconnect":
                    await Disconnect();
                    break;
                case "set":
                    await Set(parts);
                    break;
                case "get":
                    await Get(parts);
                    break;
                case "del":
                    await Del(parts);
                    break;
                default:
                    Console.WriteLine($"Unknown command: {command}");
                    break;
            }
        }

        private static async Task Connect(string[] parts)
        {
            if (parts.Length != 2)
            {
                Console.WriteLine("Usage: connect <address>");
                return;
            }

            string address = parts[1];

            // TODO: Implement gRPC connection logic here
            // For now, simulate the connection
            _currentServerAddress = address;
            _isConnected = true;
            Console.WriteLine($"Connected to {address}");
            await Task.CompletedTask;
        }

        private static async Task Disconnect()
        {
            if (!_isConnected)
            {
                Console.WriteLine("Not connected to any server.");
                return;
            }

            // TODO: Implement gRPC disconnection logic here
            // For now, simulate the disconnection
            _currentServerAddress = null;
            _isConnected = false;
            Console.WriteLine("OK");
            await Task.CompletedTask;
        }

        private static async Task Set(string[] parts)
        {
            if (!_isConnected)
            {
                Console.WriteLine("Not connected to any server.");
                return;
            }

            if (parts.Length < 3)
            {
                Console.WriteLine("Usage: set <key> <value>");
                return;
            }

            // Extract key and value, handling multi-line values
            string key = parts[1].Trim('"');
            string value = string.Join(" ", parts.Skip(2)).Trim('"');

            if (value.EndsWith(';'))
            {
                value = value.TrimEnd(';');
            }

            // TODO: Implement gRPC set logic here
            // For now, simulate the operation
            Console.WriteLine("OK");
            await Task.CompletedTask;
        }

        private static async Task Get(string[] parts)
        {
            if (!_isConnected)
            {
                Console.WriteLine("Not connected to any server.");
                return;
            }

            if (parts.Length != 2)
            {
                Console.WriteLine("Usage: get <key>");
                return;
            }

            string key = parts[1].Trim('"');

            // TODO: Implement gRPC get logic here
            // For now, simulate the operation
            Console.WriteLine("value"); // Replace with the actual value from gRPC response
            await Task.CompletedTask;
        }

        private static async Task Del(string[] parts)
        {
            if (!_isConnected)
            {
                Console.WriteLine("Not connected to any server.");
                return;
            }

            if (parts.Length != 2)
            {
                Console.WriteLine("Usage: del <key>");
                return;
            }

            string key = parts[1].Trim('"');

            // TODO: Implement gRPC delete logic here
            // For now, simulate the operation
            Console.WriteLine("OK");
            await Task.CompletedTask;
        }
    }
}
