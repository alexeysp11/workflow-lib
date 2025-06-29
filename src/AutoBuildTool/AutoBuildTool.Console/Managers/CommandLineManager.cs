using AutoBuildTool.Console.Logging;
using System.Diagnostics;
using System.Linq;

namespace AutoBuildTool.Console.Managers
{
    /// <summary>
    /// .
    /// </summary>
    public class CommandLineManager
    {
        private Logger _logger;
        
        public CommandLineManager(Logger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Run the command using the command line.
        /// </summary>
        public void RunCommandPrompt(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new System.ArgumentNullException(nameof(command), "Command is incorrect");
            
            _logger.LogMessage("Press Enter to continue...");
            System.Console.ReadLine();

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            // string output = ParseCommandLineOutput(cmd.StandardOutput.ReadToEnd());
            string output = cmd.StandardOutput.ReadToEnd();
            _logger.LogMessage(output);
        }

        /// <summary>
        /// Parses the output of a command line command to remove OS version and current directory information.
        /// </summary>
        private string ParseCommandLineOutput(string output)
        {
            string[] lines = output.Split('\n');
            // lines = lines.Skip(4).SkipLast(2).ToArray();
            return string.Join("\n", lines);
        }
    }
}