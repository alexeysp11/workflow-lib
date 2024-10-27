using System.Collections.Generic;

namespace AutoBuildTool.Models
{
    /// <summary>
    /// Build automation tool config settings.
    /// </summary>
    public class BuildAutomationToolSettings
    {
        /// <summary>
        /// Projects to build.
        /// </summary>
        public IReadOnlyList<ProjectSettings> Projects { get; set; }

        /// <summary>
        /// MSBuild path.
        /// </summary>
        public string MSBuildPath { get; set; }
    }
}