using System.Collections.Generic;

namespace AutoBuildTool.Common.Models
{
    /// <summary>
    /// Config settings for the AutoBuildTool application.
    /// </summary>
    public class AutoBuildToolSettings
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