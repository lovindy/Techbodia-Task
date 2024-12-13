using System;
using System.Collections.Generic;

namespace NotificationChannelParser
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Notification Channel Parser");
            Console.WriteLine("Enter notification title (type 'exit' to quit):");

            while (true)
            {
                // Get input from user
                string input = Console.ReadLine() ?? string.Empty;

                // Check if user wants to exit
                if (input.ToLower() == "exit")
                {
                    break;
                }

                // Parse the channels
                List<string> channels = ParseChannels(input);

                // Display results
                if (channels.Count > 0)
                {
                    Console.WriteLine($"Receive channels: {string.Join(", ", channels)}");
                }
                else
                {
                    Console.WriteLine("No valid channels found");
                }

                Console.WriteLine("\nEnter notification title (type 'exit' to quit):");
            }
        }

        static List<string> ParseChannels(string title)
        {
            // List of valid channels
            var validChannels = new List<string> { "BE", "FE", "QA", "URGENT" };

            // List to store found channels
            var foundChannels = new List<string>();

            // Split the input by ']' to separate tags
            string[] parts = title.Split(']');

            foreach (string part in parts)
            {
                // Get the text between '[' and ']'
                string tag = part.Trim('[', ' ');

                // Convert to uppercase for comparison
                tag = tag.ToUpper();

                // Add to found channels if it's valid
                if (validChannels.Contains(tag))
                {
                    foundChannels.Add(tag);
                }
            }

            // Sort the channels alphabetically
            foundChannels.Sort();

            return foundChannels;
        }
    }
}