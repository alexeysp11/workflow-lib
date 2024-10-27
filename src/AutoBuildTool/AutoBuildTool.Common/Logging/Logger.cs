using Microsoft.Extensions.Logging;

namespace AutoBuildTool.Logging
{
    /// <summary>
    /// .
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Log the specified message to the console.
        /// </summary>
        public void LogMessage(
            string message, 
            LogLevel logLevel = LogLevel.Information, 
            bool isNewLine = false)
        {
            // Set color.
            if (logLevel == LogLevel.Warning)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Green;
            }
            else if (logLevel == LogLevel.Error)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
            }
            
            // Print message.
            if (isNewLine)
            {
                System.Console.WriteLine();
            }
            System.Console.WriteLine(message);

            // Reset color.
            System.Console.ResetColor();
        }
    }
}