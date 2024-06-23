using BuildAutomationTool.Managers;
using BuildAutomationTool.Logging;

namespace BuildAutomationTool.NetFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Configuration.
            var logger = new Logger();
            var commandLineManager = new CommandLineManager(logger);

            // Read file.

            // Run command.
            logger.LogMessage("Build started");
            var command = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe C:\\Users\\User\\Documents\\proj\\BuildAutomationTool\\data\\ComPortComms\\ComPortComms.sln";
            logger.LogMessage("command: " + command);
            commandLineManager.RunCommandPrompt(command);

            // Prin out the result.
            logger.LogMessage("Command executed");
        }
    }
}
